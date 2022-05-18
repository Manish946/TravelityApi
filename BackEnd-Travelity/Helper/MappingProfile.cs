using AutoMapper;
using BackEnd_Travelity.Domain;
//To get ours DTOs to map them for better design of database struckter
using BackEnd_Travelity.DTO.Admin_DTOModel;
using BackEnd_Travelity.DTO.AVBudget_DTOModel;
using BackEnd_Travelity.DTO.Budget_DTOModel;
using BackEnd_Travelity.DTO.BudgetReport_DTOModel;
using BackEnd_Travelity.DTO.Chat_DTOModel;
using BackEnd_Travelity.DTO.Comment_DTOModel;
using BackEnd_Travelity.DTO.Coupon_DTOModel;
using BackEnd_Travelity.DTO.Explorer_DTOModel;
using BackEnd_Travelity.DTO.Friend_DTOModel;
using BackEnd_Travelity.DTO.FriendRequest_DTOModel;
using BackEnd_Travelity.DTO.Group_DTOModel;
using BackEnd_Travelity.DTO.Likes_DTOModel;
using BackEnd_Travelity.DTO.MostVisited_DTOModel;
using BackEnd_Travelity.DTO.Permission_DTOModel;
using BackEnd_Travelity.DTO.Picture_DTOModel;
using BackEnd_Travelity.DTO.Place_DTOModel;
using BackEnd_Travelity.DTO.Ticket_DTOModel;
using BackEnd_Travelity.DTO.User_DTOModel;

namespace BackEnd_Travelity.Helper
{
    // Profile is inherited from Auto mapper which has useful functions to map the profile.
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapper for Admins
            CreateMap<Admin, AdminModel>().ReverseMap();
            CreateMap<Admin, CreateAdminModel>().ReverseMap();
            CreateMap<Admin, UpdateAdminModel>().ReverseMap();

            //Mapper for Available Budgets
            CreateMap<AVBudget, AvBudgetModel>().ReverseMap();
            CreateMap<AVBudget, CreateAdminModel>().ReverseMap();
            CreateMap<AVBudget, UpdateAVBudgetModel>().ReverseMap();

            //Mapper for Budgets
            CreateMap<Budget, BudgetModel>().ReverseMap();
            CreateMap<Budget, CreateBudgetModel>().ReverseMap();
            CreateMap<Budget, UpdateBudgetModel>().ReverseMap();


            //Mapper for Budget Reports
            CreateMap<BudgetReport, BudgetReportModel>().ReverseMap();
            CreateMap<BudgetReport, CreateBudgetReportModel>().ReverseMap();
            CreateMap<BudgetReport, UpdateBudgetReportModel>().ReverseMap();

            //Mapper for Chats
            CreateMap<Chat, ChatModel>().ReverseMap();
            CreateMap<Chat, CreateChatModel>().ReverseMap();

            //Mapper for Comments
            CreateMap<Comment, CommentModel>().ReverseMap();
            CreateMap<Comment, CreateCommentModel>().ReverseMap();

            //Mapper for Coupons 
            CreateMap<Coupon, CouponModel>().ReverseMap();
            CreateMap<Coupon, CreateCouponModel>().ReverseMap();
            CreateMap<Coupon, UpdateCouponModel>().ReverseMap();

            //Mapper for Explorers
            CreateMap<Explorer, ExplorerModel>().ReverseMap();
            CreateMap<Explorer, CreateExplorerModel>().ReverseMap();

            //Mapper for Friends
            CreateMap<Friend, FriendModel>().ReverseMap();
            CreateMap<Friend, CreateFriendModel>().ReverseMap();
            CreateMap<Friend, UpdateFriendModel>().ReverseMap();

            //Mapper for FriendRequest
            CreateMap<FriendRequest, FriendRequestModel>().ReverseMap();
            CreateMap<FriendRequest, CreateFriendRequestModel>().ReverseMap();
            CreateMap<FriendRequest, UpdateFriendRequestModel>().ReverseMap();

            //Mapper for Groups
            CreateMap<Group, GroupModel>().ReverseMap();
            CreateMap<Group, CreateGroupModel>().ReverseMap();
            CreateMap<Group, UpdateGroupModel>().ReverseMap();

            //Mapper for Likes
            CreateMap<Likes, LikesModel>().ReverseMap();
            CreateMap<Likes, CreateLikesModel>().ReverseMap();
            CreateMap<Likes, UpdateLikesModel>().ReverseMap();

            //Mapper for Most Visiteds
            CreateMap<MostVisited, MostVisitedModel>().ReverseMap();
            CreateMap<MostVisited, CreateMostVisitedModel>().ReverseMap();
            CreateMap<MostVisited, UpdateMostVisitedModel>().ReverseMap();

            //Mapper for permissions
            CreateMap<Permission, PermissionModel>().ReverseMap();
            CreateMap<Permission, CreatePermissionModel>().ReverseMap();
            CreateMap<Permission, UpdatePermissionModel>().ReverseMap();

            //Mapper for Pictures
            CreateMap<Picture, PictureModel>().ReverseMap();
            CreateMap<Picture, CreatePictureModel>().ReverseMap();

            //Mapper for Places
            CreateMap<Place, PlaceModel>().ReverseMap();

            //Mapper for Tickets
            CreateMap<Ticket, TicketModel>().ReverseMap();
            CreateMap<Ticket, CreateTicketModel>().ReverseMap();
            CreateMap<Ticket, UpdateTicketModel>().ReverseMap();

            //Mapper for Users
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, UpdateUserModel>().ReverseMap();
        }
    }
}
