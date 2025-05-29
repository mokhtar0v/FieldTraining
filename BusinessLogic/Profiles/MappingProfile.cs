using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Freelancer, FreelancerDTO>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<CreateJobDTO, Job>();
            CreateMap<UpdateJobDTO, Job>();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<Conversation, ConversationDTO>().ReverseMap();
            CreateMap<JobApplication, JobApplicationDTO>().ReverseMap();
            CreateMap<JobApplication, CreateJobApplicationDTO>();
        }
    }
}
