using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;
using Vidly.Dtos;
using AutoMapper;
using System.Runtime.Caching;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dbContext;

        // GET: Customers
        public ActionResult Index()
        {
            //Cache data eg Genre List
            //if (MemoryCache.Default["Genres"] == null)
            //    MemoryCache.Default["Genres"] = _dbContext.Genre.ToList();
            //var genre = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        //form action for a new newCustomer
        public ActionResult CustomerForm()
        {
            var MembershipTypes = _dbContext.MembershipType.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = MembershipTypes
            };
            return View(viewModel);
        }

        //Action called when a user taps on the save button 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( CustomerDto Customer)
        {

       
            if (!ModelState.IsValid)
            {
                var MembershipTypes = _dbContext.MembershipType.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    Customer = GetNewCustomerMapping(Customer),
                    MembershipTypes = MembershipTypes
                };

                return View("CustomerForm",viewModel);
            }
        

            if(Customer.Id == 0)
            {
                var newCustomer = GetNewCustomerMapping(Customer);
                _dbContext.Customers.Add(newCustomer);
                _dbContext.SaveChanges();
                Customer.Id = newCustomer.Id;

            }
            else
            {
                var customerInDb = _dbContext.Customers.Single(c => c.Id == Customer.Id);
                Mapper.Map<CustomerDto, Customer>(Customer,customerInDb);
                _dbContext.SaveChanges();
            }

            
            return RedirectToAction("Index", "Customer");
        
        }

        // GET: Specific Customer Details
        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c=> c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(customer);
            }

        }

        //GET: Specific Customer Details to be edited
        public ActionResult Edit(int Id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == Id);

            if(customer == null)
            
               return HttpNotFound();
               
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipType.ToList()
            };
            
            return View("CustomerForm", viewModel);
        }

        public Customer GetNewCustomerMapping(CustomerDto customer)
        {
            var Customer = Mapper.Map<CustomerDto, Customer>(customer);
            return Customer;
        }



    }
}

