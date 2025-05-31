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
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
            //CreateMap<Customer, CustomerDTO>();
            CreateMap<Freelancer, FreelancerDTO>().ReverseMap();
            CreateMap<Freelancer, UpdateFreelancerDTO>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<Job, JobDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));
            CreateMap<CreateJobDTO, Job>().ReverseMap();
            CreateMap<UpdateJobDTO, Job>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<Conversation, ConversationDTO>().ReverseMap();
            CreateMap<JobApplication, JobApplicationDTO>().ReverseMap();
            CreateMap<JobApplication, CreateJobApplicationDTO>();
        }
    }
}
