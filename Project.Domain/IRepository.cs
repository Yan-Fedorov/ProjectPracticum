using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public interface IRepository<T,Y>
    {
        //T Create(Y data);
        IEnumerable<T> GetItemsList(); // получение всех объектов
        T GetElementById(Guid id); // получение одного объекта по id
        T Add(Y item); // добавление объекта
        void Update(Guid id, Y item); // обновление объекта
        void Delete(Guid id); // удаление объекта по id
    }
}
