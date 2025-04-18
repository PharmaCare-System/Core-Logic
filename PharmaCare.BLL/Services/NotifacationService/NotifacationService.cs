//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Notification.Dal;
//using PharmaCare.BLL.DTOs.NotifaciionDTOs;

//namespace PharmaCare.BLL.Services.NotifacationService
//{
//    public class NotifacationService:INotifacationService
//    {
//        private readonly INotifacationRepository  _notifacationRepository;
//        public NotifacationService(INotifacationRepository notifacationRepository)
//        {
//            _notifacationRepository = notifacationRepository;
//        }

//        public void Add(NotifacationAddDto notifacationAddDto)
//        {
//            var notifacation = new DAL.Models.Notifacation
//            {
//                SenderId = notifacationAddDto.SenderId,
//                Message = notifacationAddDto.Message,
//                CreatedAt = DateTime.Now,
//                IsRead = false,
//                Sender = notifacationAddDto.Sender
//            };
            
            
//            _notifacationRepository.Add(notifacation);
//        }

//        public void Delete(int id)
//        {
//            var notifacation = _notifacationRepository.GetById(id);
//            if (notifacation != null)
//            {
//                _notifacationRepository.Delete(notifacation);
//            }
//            else
//            {
//                throw new Exception("Notifacation not found");
//            }
//        }

//        public IEnumerable<NotifacationReadDto> GetAll()
//        {
//            var notifacations = _notifacationRepository.GetAll();
//            var notifacationDtos = notifacations.Select(n => new NotifacationReadDto
//            {
//                Id = n.Id,
//                SenderId = n.SenderId,
//                Message = n.Message,
//                CreatedAt = n.CreatedAt,
//                IsRead = n.IsRead,
//                Sender = n.Sender
//            }).ToList();
//            return notifacationDtos;
//        }

//        public NotifacationReadDto GetById(int id)
//        {
//            var notifacation = _notifacationRepository.GetById(id);
//            if (notifacation == null)
//            {
//                throw new Exception("Notifacation not found");
//            }
//            var notifacationDto = new NotifacationReadDto
//            {
//                Id = notifacation.Id,
//                SenderId = notifacation.SenderId,
//                Message = notifacation.Message,
//                CreatedAt = notifacation.CreatedAt,
//                IsRead = notifacation.IsRead,
//                Sender = notifacation.Sender
//            };
//            return notifacationDto;
//        }

//        public void Update(NotifacationUpdateDto notifacationUpdateDto)
//        {
//            var notifacation = _notifacationRepository.GetById(notifacationUpdateDto.Id);
//            if (notifacation != null)
//            {
//                notifacation.Message = notifacationUpdateDto.Message;
//                notifacation.IsRead = notifacationUpdateDto.IsRead;
//                _notifacationRepository.Update(notifacation);
//            }
//            else
//            {
//                throw new Exception("Notifacation not found");
//            }
//        }
//    }
//}
