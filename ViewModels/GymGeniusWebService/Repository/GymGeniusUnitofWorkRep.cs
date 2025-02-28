namespace GymGeniusWebService.Repository
{
    public class GymGeniusUnitofWorkRep
    {
        CoachRepository coachRepository;
        ExersiceRepository exersiceRepository;
        MachinesRepository machinesRepository;
        MusclesRepository musclesRepository;
        PeopleRepository peopleRepository;
        PlanRepository planRepository;
        DBContext dBContext;
        

        public GymGeniusUnitofWorkRep(DBContext dBContext)
        {
            this.dBContext = DBContext.GetInstance();
        }
        public CoachRepository CoachRepository
        {
            get
            {
                if(this.coachRepository == null)
                    this.coachRepository = new CoachRepository(this.dBContext);
                return this.coachRepository;
            }
        }
        public ExersiceRepository ExersiceRepository
        {
            get
            {
                if (this.exersiceRepository == null)
                    this.exersiceRepository = new ExersiceRepository(this.dBContext);
                return this.ExersiceRepository;
            }

        }
        public MachinesRepository MachinesRepository
        {
            get
            {
                if (this.machinesRepository == null)
                    this.machinesRepository = new MachinesRepository(this.dBContext);
                return this.machinesRepository;
            }
        }
        public MusclesRepository MusclesRepository
        {
            get
            {
                if (this.musclesRepository == null)
                    this.musclesRepository = new MusclesRepository(this.dBContext);
                return this.musclesRepository;
            }
        }
       
        public PeopleRepository PeopleRepository
        {
            get
            {
                if (this.peopleRepository == null)
                    this.peopleRepository = new PeopleRepository(this.dBContext);
                return this.peopleRepository;
            }
        }
        public PlanRepository PlanRepository
        {
            get
            {
                if (this.planRepository == null)
                    this.planRepository = new PlanRepository(this.dBContext);
                return this.planRepository;
            }
        }
    }
}
