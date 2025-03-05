using GymGeniusWebService.Factory_Methods;

namespace GymGeniusWebService.Repository
{
    public class GymGeniusUnitofWork
    {
        CoachRepository coachRepository;
        ExersiceRepository exersiceRepository;
        MachinesRepository machinesRepository;
        MusclesRepository musclesRepository;
        PeopleRepository peopleRepository;
        PlanRepository planRepository;

        DBContext Dbcontext;

        public GymGeniusUnitofWork(DBContext dBContext)
        {
            this.Dbcontext = DBContext.GetInstance();

        }
        public CoachRepository CoachRepository
        {
            get
            {
                if (this.coachRepository == null)
                {
                    this.coachRepository = new CoachRepository(this.Dbcontext);
                }
                return this.coachRepository;
            }
        }

        public ExersiceRepository ExersiceRepository
        {
            get
            {
                if (this.exersiceRepository == null)
                {
                    this.exersiceRepository = new ExersiceRepository(this.Dbcontext);
                }
                return this.exersiceRepository;
            }
        }

        public MachinesRepository MachinesRepository
        {
            get
            {
                if (this.machinesRepository == null)
                {
                    this.machinesRepository = new MachinesRepository(this.Dbcontext);
                }
                return this.machinesRepository;
            }
        }

        public MusclesRepository MusclesRepository
        {
            get
            {
                if (this.musclesRepository == null)
                {
                    this.machinesRepository = new MachinesRepository(this.Dbcontext);
                }
                return this.musclesRepository;
            }
        }

        public PeopleRepository PeopleRepository
        {
            get
            {
                if (this.peopleRepository == null)
                {
                    this.peopleRepository = new PeopleRepository(this.Dbcontext);
                }
                return this.peopleRepository;
            }
        }


        public PlanRepository PlanRepository
        {
            get
            {
                if (this.planRepository == null)
                {
                    this.planRepository = new PlanRepository(this.Dbcontext);
                }
                return this.planRepository;
            }
        }
    }



}


