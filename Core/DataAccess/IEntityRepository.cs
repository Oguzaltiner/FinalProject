using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint generic kısıt demek
    //T: referans tip olabilir
    //class: Ientity olsun sadece bizim istediğimiz clasları yazsın
    //ya IEntity olur yada implement olanlar olur
    //newlenebilir olmalı(IEntity newlenemez onu yazamayız.)
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //filtereler yazabilmemiz için örn kategoriye göre listele
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
