using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.X509;
using ProductManagement.DataAccess.DbContexts;
using ProductManagement.DataAccess.Interfaces;
using ProductManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProductManagement.DataAccess.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private ProductDbContext _productDbContext;
        public ComputerRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public Computer GetComputerById(int id)
        {
            return _productDbContext.Computer.FirstOrDefault(x => x.ComputerId == id);
        }

        public IEnumerable<Computer> GetComputers()
        {
            return _productDbContext.Computer;
        }


        public IEnumerable<Computer> SearchComputersByComputerName(string computerName, string ownerName, string cpu, string ram, string gpu, string hdd)
        {
            Expression<Func<Computer, bool>> exprComputerName = x => x.ComputerName.Contains(computerName);
            Expression<Func<Computer, bool>> exprOwnerName = x => x.OwnerName.Contains(ownerName);
 

            var invokedExpression = Expression.Invoke(exprOwnerName, exprComputerName.Parameters);

            var body = Expression.Or(exprComputerName.Body, invokedExpression);
            var lambda = Expression.Lambda<Func<Computer, bool>>(body, exprComputerName.Parameters);

            IQueryable<Computer> query = _productDbContext.Computer;
                      
            query = query.Where(lambda);         

            return query.ToList();
        }
        public IEnumerable<Computer> SearchComputersByOwnerName(string computerName, string ownerName, string cpu, string ram, string gpu, string hdd)
        {

            Expression<Func<Computer, bool>> finalExpression = null;
            Expression < Func<Computer, bool>> expression1;
            Expression<Func<Computer, bool>> expression2;
            Expression<Func<Computer, bool>> expression3;
            Expression<Func<Computer, bool>> expression4;
            Expression<Func<Computer, bool>> expression5;
            Expression<Func<Computer, bool>> expression6;

            bool isExpressionEmpty = true;

            if (!string.IsNullOrEmpty(computerName))
            {
                expression1 = ComputerNameExpression(computerName);
                if (isExpressionEmpty == false)
		        {
                    finalExpression = Combine(finalExpression, expression1);
                }

                else
                {
                    finalExpression = expression1;
                    isExpressionEmpty = false;
                }
            }

            if (!string.IsNullOrEmpty(ownerName))
            {
                expression2 = OwnerNameExpression(ownerName);
                if (isExpressionEmpty == false)
                {
                    finalExpression = Combine(finalExpression, expression2);
                }

                else
                {
                    finalExpression = expression2;
                    isExpressionEmpty = false;
                }
            }

            if (!string.IsNullOrEmpty(cpu))
            {
                expression3 = CpuExpression(cpu);
                if (isExpressionEmpty == false)
                {
                    finalExpression = Combine(finalExpression, expression3);
                }

                else
                {
                    finalExpression = expression3;
                    isExpressionEmpty = false;
                }
            }

            if (!string.IsNullOrEmpty(ram))
            {
                expression4 = RamExpression(ram);
                if (isExpressionEmpty == false)
                {
                    finalExpression = Combine(finalExpression, expression4);
                }

                else
                {
                    finalExpression = expression4;
                    isExpressionEmpty = false;
                }
            }

            if (!string.IsNullOrEmpty(gpu))
            {
                expression5 = GpuExpression(gpu);
                if (isExpressionEmpty == false)
                {
                    finalExpression = Combine(finalExpression, expression5);
                }

                else
                {
                    finalExpression = expression5;
                    isExpressionEmpty = false;
                }
            }

            if (!string.IsNullOrEmpty(hdd))
            {
                expression6 = HddExpression(hdd);
                if (isExpressionEmpty == false)
                {
                    finalExpression = Combine(finalExpression, expression6);
                }

                else
                {
                    finalExpression = expression6;
                    isExpressionEmpty = false;
                }
            }

            IQueryable<Computer> query = _productDbContext.Computer;


            if (isExpressionEmpty)
            {
                var result = _productDbContext.Computer;
                return result;
            }
            else
            {
                var result = query.Where(finalExpression).AsEnumerable();
                return result;
            }
            
        }

        public Expression<Func<Computer, bool>> ComputerNameExpression(string computerName) 
        {
            Expression < Func<Computer, bool> > exprComputerName = x => x.ComputerName.Contains(computerName);

            return exprComputerName;
        }

        public Expression<Func<Computer, bool>> OwnerNameExpression(string ownerName)
        {
            Expression<Func<Computer, bool>> exprOwnerName = x => x.OwnerName.Contains(ownerName);

            return exprOwnerName;
        }

        public Expression<Func<Computer, bool>> CpuExpression(string cpu)
        {
            Expression<Func<Computer, bool>> exprCpu = x => x.Cpu.Contains(cpu);

            return exprCpu;
        }

        public Expression<Func<Computer, bool>> RamExpression(string ram)
        {
            Expression<Func<Computer, bool>> exprRam = x => x.Ram.Contains(ram);

            return exprRam;
        }

        public Expression<Func<Computer, bool>> GpuExpression(string gpu)
        {
            Expression<Func<Computer, bool>> exprGpu = x => x.Gpu.Contains(gpu);

            return exprGpu;
        }

        public Expression<Func<Computer, bool>> HddExpression(string hdd)
        {
            Expression<Func<Computer, bool>> exprHdd = x => x.Hdd.Contains(hdd);

            return exprHdd;
        }

        public Expression<Func<Computer, bool>> Combine(Expression<Func<Computer, bool>> final, Expression<Func<Computer, bool>> toAdd)
        {
            var body = Expression.AndAlso(final.Body, toAdd.Body);
            var lambda = Expression.Lambda<Func<Computer, bool>>(Expression.Or(
                        new SwapVisitor(final.Parameters[0],
                        toAdd.Parameters[0]).Visit(final.Body),
                        toAdd.Body), toAdd.Parameters);

            return lambda;
        }



        public Computer GetComputerDetails(int id)
        {
            //var foundProduct = _productDbContext.ComputerInstallation.Where(software => software.ComputerId == id).Select(y => y.ProductId).ToList();

            //var installedSoftware = _productDbContext.OracleProduct.Where(x => foundProduct.Contains(x.ProductId));

            // return installedSoftware;

            var computers = _productDbContext.Computer
               .Include("ComputerInstallation.OracleProduct")
               .FirstOrDefault(p => p.ComputerId == id);

            return computers;
        }

    }
    public class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }

}


