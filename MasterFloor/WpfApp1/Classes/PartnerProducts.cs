using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Data
{
    public partial class PartnerProducts
    {
        // Получаем название продукта из таблицы Products по внешнему ключу
        public string TitleProduct => Core.GetContext().Products.Where(x => x.ID == this.ProductID).FirstOrDefault()?.Title;  // символ ? перед последней точкой нужен, чтобы в случае отсутствия необходимого продука не возникла ошибка, а вывелась пустая строка 
        // Выводим дату реализации продажи
        // Для этого сначала преобразуем дату продажи к типу DateTime, чтобы получить строку в нужном формате
        // В нашем случае это будет формат "18 декабря 2024", который получается за счет использования метода ToLongDateString
        public string DateString => ((DateTime)DataSale).ToLongDateString();
    }
}
