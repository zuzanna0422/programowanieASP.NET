using programowanieASP.NET.Controllers;

namespace programowanieASP.NET.Models
{
    public class Calculator
    {
        public Operator? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public String Op
        {
            get
            {
                switch (Operator)
                {
                    case Controllers.Operator.Add:
                        return "+";
                    case Controllers.Operator.Div:
                        return "/";
                    case Controllers.Operator.Sub:
                        return "-";
                    case Controllers.Operator.Mul:
                        return "*";
                default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate()
        {
            switch (Operator)
            {
                case Controllers.Operator.Add:
                    return (double)(X + Y);
                case Controllers.Operator.Sub:
                    return (double)(X - Y);
                case Controllers.Operator.Mul:
                    return (double)(X * Y);
                case Controllers.Operator.Div:
                    return (double)(X / Y);
            default: return double.NaN;
            }
        }
    }
}
