using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;

namespace WpfApp1
{
    internal class Module4
    {
        private int CalcCountMaterial(int typeProductID, int typeMaterialID, int countProduct, double length, double width)
        {
            // Получаем записи из БД
            ProductType productType = Core.GetContext().ProductType.Where(x => x.ID ==  typeProductID).FirstOrDefault();
            if (productType == null) return -1;

            MaterialType materialType = Core.GetContext().MaterialType.Where(x => x.ID == typeMaterialID).FirstOrDefault();
            if (materialType == null) return -1;

            // Проверяем что реализовано положительное число продукции
            if (countProduct < 0)
            {
                return -1;
            }

            // Проверяем что длина и ширина продукции больше нуля
            if (length <= 0 || width <= 0)
            {
                return -1;
            }

            // Получаем "Коэффициент типа продукции" и "процент брака"
            double ratioProductType = (double)productType.Ratio;
            double percentBad = (double)materialType.ScrapRate;
            // Проверям что полученные значения больше 0
            if (ratioProductType <= 0 || percentBad <= 0)
            {
                return -1;
            }

            // Вычисляем результат
            double result = (length * width * ratioProductType) * (1 + percentBad) * countProduct; 
            // Округляем результат в большую сторону с помощью Ceiling и приводим результат к целому типу данных (int)
            int resultInt = (int)Math.Ceiling(result);

            // Возвращаем результат вычислений, который отражает необходимое количество материала для изготовления продукции определенного типа
            return resultInt;
        }
    }
}
