using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public Byte Id { get; set; }

        public String Name { get; set; }

        public Byte DurationInMonths { get; set; }

        public short SignUpFee { get; set; }

        public Byte Discount { get; set; }

        public static readonly byte UNKNOWN = 0;
        public static readonly byte PAY_AS_YOU_GO = 1;
    }
}