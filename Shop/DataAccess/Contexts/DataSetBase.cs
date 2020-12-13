using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using AutoMapper;
using Shop.Application;
using System;

namespace Shop.DataAccess.Interfaces
{
    internal abstract class DataSetBase<TModel> : IDataSet<TModel>
        where TModel: class, IUnique
    {
        public string DataSetName { get; private set; }

        protected virtual string connectionDir => Path.Combine(Environment.CurrentDirectory, "XMLdatabase");
        protected readonly List<TModel> _storage;
        protected readonly XmlSerializer _serializer;
        protected readonly IMapper _mapper;
        protected string connectionString;
        private int lastId;

        public DataSetBase()
        {
            _mapper = AutomapperFactory.GetMapper();
            DataSetName = typeof(TModel).Name;
            connectionString = Path.Combine(connectionDir, $"{DataSetName}.xml");
            _serializer = new XmlSerializer(typeof(TModel[]));
            _storage = new List<TModel>();

            if(!File.Exists(connectionString))
            {
                Directory.CreateDirectory(connectionDir);
                using (var fs = new FileStream(connectionString, FileMode.Create))
                {
                    _serializer.Serialize(fs, new TModel[0]);
                }
            }
            Refresh();
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return _storage.AsEnumerable();
        }

        public IEnumerable<TModel> GetAllByCondition(Func<TModel, bool> filter)
        {
            return _storage.Where(filter).AsEnumerable();
        }

        public virtual TModel Get(int id)
        {
            return _storage.Single(m => m.Id == id);
        }

        public virtual TModel GetByCondition(Func<TModel, bool> filter)
        {
            return _storage.FirstOrDefault(filter);
        }

        public virtual void Add(TModel model)
        {
            model.Id = ++lastId;
            _storage.Add(model);
        }

        public virtual void Edit(TModel model)
        {
            int index =_storage.FindIndex(m => m.Id == model.Id);
            _storage[index] = _mapper.Map<TModel>(model); 
        }

        public virtual void Delete(int id)
        {
            _storage.Remove(Get(id));
        }

        public virtual bool IsContains(TModel model)
        {
           return _storage.Contains(Get(model.Id));
        }

        public virtual bool IsContains(int id)
        {
            return _storage.Any(m => m.Id == id);
        }

        public virtual void Refresh()
        {
            lock(_storage)
            {
                using (var fs = new FileStream(connectionString, FileMode.OpenOrCreate))
                {
                    _storage.Clear();
                    _storage.AddRange((TModel[])_serializer.Deserialize(fs));
                }
                lastId = _storage.Any() ? _storage.Max(m => m.Id) : -1;
            }
        }
        
        public virtual void Save()
        {
            lock(_storage)
            {
                using (var fs = new FileStream(connectionString, FileMode.Create))
                {
                    _serializer.Serialize(fs, _storage.ToArray());
                }
            }
        }
    }
}