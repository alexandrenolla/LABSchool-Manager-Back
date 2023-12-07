using AutoMapper;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Models;

namespace FichaCadastroApi.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            // USUARIO
            CreateMap<UsuarioModel, UsuarioCreateDTO>();
            CreateMap<UsuarioModel, UsuarioUpdateDTO>();
            CreateMap<UsuarioModel, UsuarioReadDTO>();
            CreateMap<UsuarioModel, UsuarioLoginDTO>();
            CreateMap<UsuarioModel, UsuarioResetarSenhaDTO>();
            CreateMap<UsuarioCreateDTO, UsuarioModel>();
            CreateMap<UsuarioUpdateDTO, UsuarioModel>();

            // WHITELABEL
            CreateMap<WhiteLabelModel, WhiteLabelCreateDTO>();
            CreateMap<WhiteLabelModel, WhiteLabelUpdateDTO>();
            CreateMap<WhiteLabelModel, WhiteLabelReadDTO>();
            CreateMap<WhiteLabelCreateDTO, WhiteLabelModel>();
            CreateMap<WhiteLabelUpdateDTO, WhiteLabelModel>();


            // ENDEREÇO
            CreateMap<EnderecoModel, EnderecoCreateDTO>();
            CreateMap<EnderecoModel, EnderecoUpdateDTO>();
            CreateMap<EnderecoModel, EnderecoReadDTO>();
            CreateMap<EnderecoCreateDTO, EnderecoModel>();
            CreateMap<EnderecoUpdateDTO, EnderecoModel>();

            // EXERCICIO
            CreateMap<ExercicioModel, ExercicioCreateDTO>();
            CreateMap<ExercicioModel, ExercicioUpdateDTO>();
            CreateMap<ExercicioModel, ExercicioReadDTO>();
            CreateMap<ExercicioUpdateDTO, ExercicioModel>();
            CreateMap<ExercicioReadDTO, ExercicioModel>();
            CreateMap<ExercicioCreateDTO, ExercicioModel>();

            // AVALIAÇÃO
            CreateMap<AvaliacaoModel, AvaliacaoCreateDTO>();
            CreateMap<AvaliacaoModel, AvaliacaoUpdateDTO>();
            CreateMap<AvaliacaoModel, AvaliacaoReadDTO>();
            CreateMap<AvaliacaoCreateDTO, AvaliacaoModel>();
            CreateMap<AvaliacaoUpdateDTO, AvaliacaoModel>();

            // ATENDIMENTO
            CreateMap<AtendimentoModel, AtendimentoCreateDTO>();
            CreateMap<AtendimentoModel, AtendimentoUpdateDTO>();
            CreateMap<AtendimentoModel, AtendimentoReadDTO>();
            CreateMap<AtendimentoCreateDTO, AtendimentoModel >();
            CreateMap<AtendimentoUpdateDTO, AtendimentoModel>();
            

            // LOG
             CreateMap<LogModel, LogCreateDTO>();
             CreateMap<LogModel, LogReadDTO>();
             CreateMap<LogCreateDTO, LogModel> ();
             


        }
    }
}