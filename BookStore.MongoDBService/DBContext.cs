using BookStore.Domain.Entity;
using BookStore.Domain.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.MongoDBService
{
    public class DBContext
    {

        public IMongoCollection<Books> _books;
        public IMongoCollection<Customers> _customers;
        public IMongoCollection<Generes> _generes;
        public IMongoCollection<OrderDetails> _orderDetails;
        public IMongoCollection<Orders> _orders;
        public IMongoCollection<Payment> _payment;
        public IMongoCollection<Reviews> _reviews;
        //public IMongoCollection<User> _user;
        public DBContext(MongoDBConnectionInfo dbDetails)
        {
            var db = DBConnection.GetDatabase(dbDetails);
            _books = db.GetCollection<Books>("books");
            _customers = db.GetCollection<Customers>("customers");
            _generes = db.GetCollection<Generes>("generes");
            _orderDetails = db.GetCollection<OrderDetails>("order-details");
            _orders = db.GetCollection<Orders>("orders");
            _payment = db.GetCollection<Payment>("payment");
            _reviews = db.GetCollection<Reviews>("reviews");
            //_users = db.GetCollection<User>("users");
        }
    }
}
