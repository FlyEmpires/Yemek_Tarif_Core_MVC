using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WriterManager:IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public void WriterAdd(Writer writer)
		{
			_writerDal.Insert(writer);
		}

		public Writer WriterLogin(Writer p)
		{
			Context db = new();
			var values = (from writer in db.Writers where writer.WriterMail == p.WriterMail && writer.WriterPassword == p.WriterPassword select writer).FirstOrDefault();
			return values;
		}
	}
}
