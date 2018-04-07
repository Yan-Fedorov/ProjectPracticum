using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetBookList(); // получение всех объектов
        List<T> GetElements(); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();
    }
}
