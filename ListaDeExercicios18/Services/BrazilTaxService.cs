using System;

namespace ListaDeExercicios18.Services
{
    class BrazilTaxService : ITaxService
    {
        public double Tax(double amouth)
        {
            if (amouth <= 100.00)
            {
                return amouth * 0.2;
            } else
            {
                return amouth * 0.15;
            }
        }
    }
}
