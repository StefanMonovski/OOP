using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Facade
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            Car = new Car();
        }

        public Car Build()
        {
            return Car;
        }

        public CarInfoBuilder Info()
        {
            return new CarInfoBuilder(Car);
        }

        public CarAddressBuilder Address()
        {
            return new CarAddressBuilder(Car);
        }
    }
}
