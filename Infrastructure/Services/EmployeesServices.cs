using Domain.Dtos;
using Dapper;
using Npgsql;
namespace Infrastructure.Services;

public class EmployeesServices
{
    string connString = "Server=localhost; Port=5432; Database= Home; User Id=postgres; Password=koma;";
    public EmployeesServices()
    {

    }
    public List<DtosEmployee> GetEmployees()
    {

        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = "SELECT employee_id as Id, first_name as FirstName,last_name LastName,email_address as Email, birth_date as BirthDate from employee Order By employee_id;";
            var result = conn.Query<DtosEmployee>(sql);
            return result.ToList();
        }
    }
    public DtosEmployee AddEmployee(DtosEmployee employee)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = "insert INTO employee(first_name,last_name,email_address,birth_date) values (@FirstName,@LastName,@Email,@BirthDate)";
            var result = conn.Execute(sql, employee);
            return employee;
        }
    }
    public void DeleteEmployee(int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"delete from employee where employee_id ={id}";
            var result = conn.Execute(sql);
        }
    }
    public DtosEmployee GetById(int id){
        using(var conn= new NpgsqlConnection(connString)){
            var sql= $"select employee_id as Id, first_name as FirstName, last_name as LastName , email_address as Email, birth_date as BirthDate from employee where employee_id ={id}";
            var result = conn.QuerySingle<DtosEmployee>(sql);
            return result;
        }

    }
    public void UpdateEmployee(DtosEmployee employee){
        using (var conn = new NpgsqlConnection(connString)){
            var sql = $"update employee set first_name = '{employee.FirstName}', last_name ='{employee.LastName}', email_address='{employee.Email}', birth_date='{employee.BirthDate}' where employee_id={employee.Id} ";
            var result= conn.Execute(sql);
        }
    }
}
