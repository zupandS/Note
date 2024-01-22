using AutoMapper;
using Note.Application.Commands.AddNotepadCommand;
using Note.Application.Commands.UpdateNotepadCommand;
using Note.Application.Responses;
using Note.Core.Entities;

namespace Note.Application.Mapper
{
    public class NotepadMapperProfile : Profile
    {
        public NotepadMapperProfile()
        {
            CreateMap<AddNotepadCommand, Notepad>().ReverseMap();
            CreateMap<UpdateNotepadCommand, Notepad>().ReverseMap();
            CreateMap<Notepad, NotepadResponse>().ReverseMap();
        }
    }
}