﻿using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public abstract class CrudFactory
    {
        protected SqlDAO _sqlDao;

        // Definir metodos del contrato
        // C  = create
        // R  = retrieve
        // U  = update
        // D  = delete

        public abstract void Create(BaseDTO baseDTO);
        public abstract void Update(BaseDTO baseDTO);
        public abstract void Delete(BaseDTO baseDTO);
        public abstract T RetrieveById<T>(int iD);   
        public abstract List<T> RetrieveAll<T>();

    }
}
