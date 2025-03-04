
using AutoMapper;
using ExaminantionSystem_R3.DTOs.Profiles;
using ExaminantionSystem_R3.Mapper;
using ExaminantionSystem_R3.Models;
using ExaminantionSystem_R3.Repositories;
using ExaminantionSystem_R3.Services;

namespace ExaminantionSystem_R3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<GeneralRepository<Question>>();
            builder.Services.AddScoped<GeneralRepository<Course>>();
            builder.Services.AddScoped<GeneralRepository<Exam>>();
            builder.Services.AddScoped<GeneralRepository<ExamQuestion>>();
            builder.Services.AddScoped<GeneralRepository<Choice>>();
            builder.Services.AddScoped<QuestionService>();
            builder.Services.AddScoped<CourseService>();
            builder.Services.AddScoped<ExamService>();
            builder.Services.AddScoped<ExamQuestionService>();
            builder.Services.AddScoped<ChoiceService>();
            builder.Services.AddAutoMapper(typeof(QuestionProfile).Assembly);
            var app = builder.Build();
            AutoMapperHelper.Mapper = app.Services.GetService<IMapper>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
