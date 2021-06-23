using SQLite;
using System;
using System.Collections.Generic;
using TcheAlerta.Data.Repositories.Interfaces;
using TcheAlerta.Models;

namespace TcheAlerta.Data.Repositories
{
    public class AlertaRepository : IRepository<Alerta>
    {
        DBSqLite _dataBase;

        public AlertaRepository() {
            _dataBase = new DBSqLite();
        }

        public void AddAsync(Alerta entity) {
            _dataBase.SqLiteConn.Insert(entity);
        }

        public void DeleteAsync(Alerta entity) {
            _dataBase.SqLiteConn.Delete(entity);
        }

        public Alerta GetAsync(int id) {
            return _dataBase.SqLiteConn.Table<Alerta>().FirstOrDefault(a => a.Id == id);
        }

        public List<Alerta> GetListAsync() {
            return _dataBase.SqLiteConn.Table<Alerta>().ToList();
        }

        public void UpdateAsync(Alerta entity) {
            throw new NotImplementedException();
        }
    }
}
