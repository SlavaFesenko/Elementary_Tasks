using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2EnvelopeAnalyzer
{
    public class Envelope : IComparable<Envelope>
    {
        #region Properties

        public double Weight
        {
            get
            {
                return _weight;    
            }
            set
            {
                _weight = value;
            }   
        }
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }

        }

        #endregion

        #region Fields

        private double _weight;
        private double _height;

        #endregion

        #region Constructors

        public Envelope(double weight,double height)
        {
            Weight = weight;
            Height = height;
            SetBiggerSizeAsWeight();
        }

        #endregion

        #region Methods

        private void SetBiggerSizeAsWeight()
        {
            if(this.Height > this.Weight)
            {
                double temp = this._height;
                this._height = this._weight;
                this._weight = temp;
            }  
        }
        //public int Compare(Envelope x, Envelope y)
        //{
        //    if (x == null || y == null)
        //        throw new ArgumentNullException();

        //    int result = 0;
        //    bool isFirstHeightBiggerSecondHeight = x.Height > y.Height;
        //    bool isFirstWeightBiggerSecondWeight = x.Weight > y.Weight;
         
        //    if (isFirstHeightBiggerSecondHeight && isFirstWeightBiggerSecondWeight)
        //    {
        //        result = 1;
        //    }
        //    else
        //    { 
        //        if (x.Equals(y))
        //        {
        //            result = 0;
        //        }
        //        else
        //        {
        //            result = -1;
        //        }
        //    }

        //    return result;

        //}
        public override bool Equals(object obj)
        {
            bool isEnvelopesEqual = false;

            if (obj is Envelope secondEnvelope)
            {
                isEnvelopesEqual = this.Height == secondEnvelope.Height && this.Weight == secondEnvelope.Weight;
            }
            else
            {
                throw new ArgumentNullException();
            }

            return isEnvelopesEqual;
        }
        /// <summary>
        /// Method checks if we can put one of the envelopes in the another
        /// </summary>
        /// <param name="envelope">second envelope</param>
        /// <returns>Return true, if we can put one of the envelopes in the second</returns>
        public bool IsCanPutInEnvelope(Envelope envelope)
        {
            bool result = false;
            
            if (CompareTo(envelope) > 0) //check first is bigger than second
            {
                result = true;
            }
            if(envelope.CompareTo(this) > 0) //check second is bigger than first
            {
                result = true;
            }
            
            return result;
        }

        public int CompareTo(Envelope other)
        {
            int result = 0;
            bool isFirstHeightBiggerSecondHeight = this.Height > other.Height;
            bool isFirstWeightBiggerSecondWeight = this.Weight > other.Weight;
            bool isSecondHeightBiggerFirstHeight = this.Height < other.Height;
            bool isSecondWeightBiggerFirstWeight = this.Weight < other.Weight;

            if (isFirstHeightBiggerSecondHeight && isFirstWeightBiggerSecondWeight)
            {
                result = 1;
            }
            else
            {
                if (isSecondHeightBiggerFirstHeight && isSecondWeightBiggerFirstWeight)
                {
                    result = -1;
                }
            }

            return result;
        }



        #endregion
    }
}
