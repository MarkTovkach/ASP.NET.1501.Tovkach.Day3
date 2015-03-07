using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PolynomialType
{
    public class Polynomial : IEquatable<Polynomial>
    {
        public int Power
        {
            get { return coefficients.Length - 1; }
        }

        private double[] coefficients;

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                return coefficients[i];
            }
            set
            {
                coefficients[i] = value;
            }
        }

        public Polynomial()
        {
            coefficients = new double[1];
            coefficients[0] = 0;
        }
        public Polynomial(params double[] coeffs)
        {
            double[] temp = (double[])coeffs.Clone();
            int index = 1;
            while (coeffs[coeffs.Length - index] == 0)
            {
                temp = new double[coeffs.Length - 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = coeffs[i];
                }
                index++;
            }
            coefficients = temp;
        }
        private Polynomial(int quantity)
        {
            coefficients = new double[quantity];
        }

        /// <summary>
        /// Computes the monomial x^power. 
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public static Polynomial Monomial(int power)
        {
            double[] coeffs = new double[power + 1];

            for (int i = 0; i < power; i++)
                coeffs[i] = 0;

            coeffs[power] = 1;

            return new Polynomial(coeffs);
        }

        /// <summary>
        /// Method of calculation polynomial with specified value of X
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Calculate(double x)
        {
            double result = 0;
            for (int i = Power; i >= 0; i--)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }
            return result;
        }

        /// <summary>
        /// Overload for binary summation
        /// </summary>
        /// <param name="leftOp"></param>
        /// <param name="rightOp"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial leftOp, Polynomial rightOp)
        {
            int tempMaxPower = leftOp.Power < rightOp.Power ? rightOp.Power : leftOp.Power;
            Polynomial result = new Polynomial(tempMaxPower + 1);
            for (int i = 0; i <= tempMaxPower; i++)
            {
                if (i > rightOp.Power) result[i] = leftOp[i];
                else if (i > leftOp.Power) result[i] = rightOp[i];
                else result[i] = leftOp[i] + rightOp[i];
            }
            return result;
        }
        public Polynomial Sum(Polynomial leftOp, Polynomial rightOp)
        {
            return leftOp + rightOp;
        }

        /// <summary>
        /// Overload for unary negation '-'
        /// </summary>
        /// <param name="leftOp"></param>
        /// <param name="rightOp"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial operand)
        {
            Polynomial result = new Polynomial(operand.Power + 1);
            for (int i = 0; i <= operand.Power; i++)
            {
                result[i] = -operand[i];
                Debug.WriteLine("{0}", result[i]);
            }
            return result;
        }

        /// <summary>
        /// Overload for binary subtraction
        /// </summary>
        /// <param name="leftOp"></param>
        /// <param name="rightOp"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial leftOp, Polynomial rightOp)
        {
            return leftOp + (-rightOp);
        }

        public Polynomial Subtraction(Polynomial leftOp, Polynomial rightOp)
        {
            return leftOp - rightOp;
        }

        /// <summary>
        /// Overload for binary multiplying
        /// </summary>
        /// <param name="leftOp"></param>
        /// <param name="rightOp"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial leftOp, Polynomial rightOp)
        {
            Polynomial result = new Polynomial();

            for (int i = 0; i <= leftOp.Power; i++)
                for (int j = 0; j <= rightOp.Power; j++)
                {
                    result += (leftOp[i] * rightOp[j] * Monomial(i + j));

                }
            return result;
        }

        /// <summary>
        /// Overload for multiplication on constant
        /// </summary>
        /// <param name="leftOp">Constant</param>
        /// <param name="rightOp">Polynomial</param>
        /// <returns></returns>
        public static Polynomial operator *(double leftOp, Polynomial rightOp)
        {
            return rightOp * leftOp;
        }

        public static Polynomial operator *(Polynomial leftOp, double rightOp)
        {
            Polynomial result = new Polynomial(leftOp.Power + 1);
            for (int i = 0; i <= leftOp.Power; i++)
            {
                result[i] = leftOp[i] * rightOp;
            }
            return result;
        }

        public Polynomial Multiply(Polynomial leftOp, Polynomial rightOp)
        {
            return leftOp * rightOp;
        }

        public static bool operator ==(Polynomial leftOp, Polynomial rightOp)
        {
            if ((((object)leftOp) == null) || (((object)rightOp) == null))
                return Object.Equals(leftOp, rightOp);
            return leftOp.Equals(rightOp);
        }

        public static bool operator !=(Polynomial leftOp, Polynomial rightOp)
        {
            if (leftOp == null || rightOp == null)
            {
                return !Object.Equals(leftOp, rightOp);
            }
            return !(leftOp.Equals(rightOp));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (Power >= 0)
            {
                result.Append(String.Format("{0}", this[0]));
                if (Power >= 1)
                {
                    result.Append(String.Format(" + {0}*x", this[1]));

                    if (Power >= 2)
                    {
                        for (int i = 2; i <= Power; i++)
                        {
                            result.Append(String.Format(" + {0}*x^{1}", this[i], i));
                        }
                    }
                }
            }
            else
            {
                result.Append(String.Empty);
            }
            return result.ToString();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || (GetType() != obj.GetType()))
            {
                return false;
            }

            Polynomial polynomObj = obj as Polynomial;
            if (polynomObj == null)
            {
                return false;
            }
            else
            {
                if (this.Power != polynomObj.Power)
                {
                    return false;
                }
                else
                {
                    return Equals(polynomObj);
                }
            }
        }

        /// <summary>
        /// Equals implementation for Polynomial object
        /// </summary>
        /// <param name="polynomial"></param>
        /// <returns></returns>
        public bool Equals(Polynomial polynomial)
        {
            for (int i = 0; i <= this.Power; i++)
            {
                if (this[i] != polynomial[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
