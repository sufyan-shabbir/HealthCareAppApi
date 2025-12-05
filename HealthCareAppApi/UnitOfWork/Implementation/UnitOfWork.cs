
using AutoMapper;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.API.Repositories.Implementation;
using HealthCareAppApi.API.Repositories.Interfaces;
using HealthCareAppApi.API.UnitOfWork.Interfaces;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAppApi.API.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IGenericRepository<User> _users;
        public IGenericRepository<User> Users =>
            _users ??= new GenericRepository<User>(_context);

        private IGenericRepository<Role> _roles;
        public IGenericRepository<Role> Roles =>
            _roles ??= new GenericRepository<Role>(_context);

        private ICompanyRepository _companies;
        public ICompanyRepository companyRepository =>
            _companies ??= new CompanyRepository(_context, _mapper);


        private IRoleRepository _roleRepository;
        public IRoleRepository roleRepository =>
            _roleRepository ??= new RoleRepository(_context, _mapper);

        private IGenericRepository<RoleModuleAccess> _roleModuleAccess;
        public IGenericRepository<RoleModuleAccess> roleModuleAccessRepository =>
            _roleModuleAccess ??= new GenericRepository<RoleModuleAccess>(_context);


        private IUserRepository _user;
        public IUserRepository userRepository =>
            _user ??= new UserRepository(_context, _mapper);

        private IAuthRepository _authRepository;
        public IAuthRepository authRepository =>
            _authRepository ??= new AuthRepository(_context, _mapper);

        private IMenuRepository _menuRepository;
        public IMenuRepository menuRepository =>
            _menuRepository ??= new MenuRepository(_context, _mapper);

        private ILookupRepository _lookupRepository;
        public ILookupRepository lookupRepository =>
            _lookupRepository ??= new LookupRepository(_context, _mapper);

        //private IPatientRepository _patientRepository; 
        //public IPatientRepository patientRepository =>
        //    _patientRepository ??= new PatientRepository(_context, _mapper);

        //private IVisitRepository _visitRepository;
        //public IVisitRepository visitRepository =>
        //    _visitRepository ??= new VisitRepository(_context, _mapper);

        //private ICityRepository _cityRepository;
        //public ICityRepository cityRepository =>
        //    _cityRepository ??= new CityRepository(_context, _mapper);

        //private IAreaRepository _areaRepository;
        //public IAreaRepository areaRepository =>
        //    _areaRepository ??= new AreaRepository(_context, _mapper);

        //private IServiceKmhRepository _serviceKmhRepository;
        //public IServiceKmhRepository serviceKmhRepository =>
        //    _serviceKmhRepository ??= new ServiceKmhRepository(_context, _mapper);

        //private IDepartmentRepository departmentRepository;
        //public IDepartmentRepository _departmentRepository =>
        //    departmentRepository ??= new DepartmentRepository(_context, _mapper);

        //private ISubDepartmentRepository subDepartmentRepository;
        //public ISubDepartmentRepository _subDepartmentRepository =>
        //    subDepartmentRepository ??= new SubDepartmentRepository(_context, _mapper);

        //private IWardProcedureRepository wardProcedureRepository;
        //public IWardProcedureRepository _wardProcedureRepository =>
        //    wardProcedureRepository ??= new WardProcedureRepository(_context, _mapper);


        //private IOPDBillMasterRepository OPDBillMasterRepository;

        //public IOPDBillMasterRepository _OPDBillMasterRepository =>
        //    OPDBillMasterRepository ??= new OPDBillMasterRepository(_context, _mapper);

        //private IOPDBillDetailRepository OPDBillDetailRepository;

        //public IOPDBillDetailRepository _OPDBillDetailRepository =>
        //    OPDBillDetailRepository ??= new OPDBillDetailRepository(_context, _mapper);

        //private IOPDPaymentRepository OPDPaymentRepository;

        //public IOPDPaymentRepository _OPDPaymentRepository =>
        //    OPDPaymentRepository ??= new OPDPaymentRepository(_context, _mapper);

        //private IOPDRefundRepository OPDRefundRepository;

        //public IOPDRefundRepository _OPDRefundRepository =>
        //    OPDRefundRepository ??= new OPDRefundRepository(_context, _mapper);

        //private ICountryRepository countryRepository;
        //public ICountryRepository _countryRepository =>
        //    countryRepository ??= new CountryRepository(_context, _mapper);

        //private IStateRepository stateRepository;
        //public IStateRepository _stateRepository =>
        //    stateRepository ??= new StateRepository(_context, _mapper);

        //private IDesignationRepository designationRepository;
        //public IDesignationRepository _designationRepository =>
        //    designationRepository ??= new DesignationRepository(_context, _mapper);

        //private IEmployeeRepository employeeRepository;
        //public IEmployeeRepository _employeeRepository =>
        //    employeeRepository ??= new EmployeeRepository(_context, _mapper);

        //private IEmployeeTypeRepository employeeTypeRepository;
        //public IEmployeeTypeRepository _employeeTypeRepository =>
        //    employeeTypeRepository ??= new EmployeeTypeRepository(_context, _mapper);

        //private INationalityRepository nationalityRepository;
        //public INationalityRepository _nationalityRepository =>
        //    nationalityRepository ??= new NationalityRepository(_context, _mapper);

        //private IStatusRepository statusRepository;
        //public IStatusRepository _statusRepository =>
        //    statusRepository ??= new StatusRepository(_context, _mapper);

        //private IPanelRepository panelRepository;
        //public IPanelRepository _panelRepository=>
        //    panelRepository ??= new PanelRepository(_context, _mapper);

        //private IPaymentModeRepository paymentModeRepository;
        //public IPaymentModeRepository _paymentModeRepository =>
        //    paymentModeRepository ??= new PaymentModeRepository(_context, _mapper);


        //private IServiceBreakupRepository serviceBreakupRepository;
        //public IServiceBreakupRepository _serviceBreakupRepository =>
        //    serviceBreakupRepository ??= new ServiceBreakupRepository(_context, _mapper);

        //private IEmployeeDepartmentRepository employeeDepartmentRepository;
        //public IEmployeeDepartmentRepository _employeeDepartmentRepository =>
        //    employeeDepartmentRepository ??= new EmployeeDepartmentRepository(_context, _mapper);

        //private IWelfareApprovalRepository welfareApprovalRepository;
        //public IWelfareApprovalRepository _welfareApprovalRepository =>
        //    welfareApprovalRepository ??= new WelfareApprovalRepository(_context, _mapper);

        //private IZakatRepository zakatRepository;
        //public IZakatRepository _zakatRepository => 
        //    zakatRepository ??= new ZakatRepository(_context, _mapper);

        //private IKMH_DIA_REG_Repository kMH_DIA_REG_Repository;
        //public IKMH_DIA_REG_Repository _kMH_DIA_REG_Repository =>
        //    kMH_DIA_REG_Repository ??= new KMH_DIA_REG_Repository(_context, _mapper);

        //private ISerolsRepository serolsRepository;
        //public ISerolsRepository _serolsRepository =>
        //    serolsRepository ??= new SerolsRepository(_context, _mapper);

        //private IDiaRegHistoryRepository diaRegHistoryRepository;
        //public IDiaRegHistoryRepository _diaRegHistoryRepository =>
        //    diaRegHistoryRepository ??= new DiaRegHistoryRepository(_context, _mapper);

        //private IEmergencyPatientRepository emergencyPatientRepository;
        //public IEmergencyPatientRepository _emergencyPatientRepository =>
        //    emergencyPatientRepository ??= new EmergencyPatientRepository(_context, _mapper);

        //private IEmergencyPatientServiceRepository emergencyPatientServiceRepository;
        //public IEmergencyPatientServiceRepository _emergencyPatientServiceRepository =>
        //    emergencyPatientServiceRepository ??= new EmergencyPatientServiceRepository(_context, _mapper);

        //private IDialysisBookingRepository dialysisBookingRepository;
        //public IDialysisBookingRepository _dialysisBookingRepository =>
        //    dialysisBookingRepository ??= new DialysisBookingRepository(_context, _mapper);

        //private IDialysisMachineRepository dialysisMachineRepository;
        //public IDialysisMachineRepository _dialysisMachineRepository =>
        //    dialysisMachineRepository ??= new DialysisMachineRepository(_context, _mapper);

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Database update failed. See inner exception for details.", dbEx);
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while saving changes.", ex);
            }
        }


        public void Dispose() =>
            _context.Dispose();
    }
}
