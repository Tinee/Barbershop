using DbConnector.Repositories;
using EntityModels.Models;

namespace BusinessLogicLayout.Functions
{
    public class UnitOfWork
    {
        private GenericRepository<User> userRepository;
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<Administrator> administratorRepository;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Schedule> scheduleRepository;
        private GenericRepository<Absence> absenceRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<OrderType> orderTypeRepository;
        private GenericRepository<AbsenceType> absenceTypeRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<OpeningHours> openingHours;
        private object DbContext;
        public UnitOfWork(object context)
        {
            this.DbContext = context;
        }
        public GenericRepository<User> UserRepository
        {
            get
            {               
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(DbContext);
                }
                return userRepository;
            }
        }
        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenericRepository<Employee>(DbContext);
                }
                return employeeRepository;
            }
        }

        public GenericRepository<Administrator> AdministratorRepository
        {
            get
            {
                if (this.administratorRepository == null)
                {
                    this.administratorRepository = new GenericRepository<Administrator>(DbContext);
                }
                return administratorRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(DbContext);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Schedule> ScheduleRepository
        {
            get
            {

                if (this.scheduleRepository == null)
                {
                    this.scheduleRepository = new GenericRepository<Schedule>(DbContext);
                }
                return scheduleRepository;
            }
        }

        public GenericRepository<Absence> AbsenceRepository
        {
            get
            {

                if (this.absenceRepository == null)
                {
                    this.absenceRepository = new GenericRepository<Absence>(DbContext);
                }
                return absenceRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {

                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(DbContext);
                }
                return orderRepository;
            }
        }

        public GenericRepository<OrderType> OrderTypeRepository
        {
            get
            {

                if (this.orderTypeRepository == null)
                {
                    this.orderTypeRepository = new GenericRepository<OrderType>(DbContext);
                }
                return orderTypeRepository;
            }
        }

        public GenericRepository<AbsenceType> AbsenceTypeRepository
        {
            get
            {

                if (this.absenceTypeRepository == null)
                {
                    this.absenceTypeRepository = new GenericRepository<AbsenceType>(DbContext);
                }
                return absenceTypeRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(DbContext);
                }
                return categoryRepository;
            }
        }
        public GenericRepository<OpeningHours> OpeningHoursRepository
        {
            get
            {
                if (this.openingHours == null)
                {
                    this.openingHours = new GenericRepository<OpeningHours>(DbContext);
                }
                return openingHours;
            }
        }
    }
}