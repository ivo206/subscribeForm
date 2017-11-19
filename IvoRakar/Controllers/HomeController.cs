using IvoRakar.Business.Definitions;
using IvoRakar.Business.Enums;
using IvoRakar.Business.Persistence;
using IvoRakar.Business.Persistence.Repositories;
using IvoRakar.Models;
using IvoRakar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IvoRakar.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private ISubscriberRepository _subscriberRepository;
         
        public HomeController(IUnitOfWork unitOfWork, ISubscriberRepository subscriberRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriberRepository = subscriberRepository;
        }

        public ActionResult Index()
        {
            var viewModel = new SubscriberViewModel();

            return View(viewModel);
        }


        public ActionResult Subscribe(Subscriber subscriber)
        {
            var viewModal = new SubscriberViewModel(subscriber);

            if (!ModelState.IsValid)
            {
                viewModal.Status = new Status { Message = SubscribeFormDefinitions.ErroreMessage, Type = StatusType.danger };
                return PartialView("_FormFields", viewModal);
            }

            if (_subscriberRepository.Get(subscriber.Email) != null)
            {
                viewModal.Status = new Status { Message = SubscribeFormDefinitions.DuplicateMessage, Type = StatusType.danger };
                return PartialView("_FormFields", viewModal);
            }

            _subscriberRepository.Add(subscriber);
            _unitOfWork.Complete();

            viewModal.Status = new Status { Message = SubscribeFormDefinitions.SuccessMessage, Type = StatusType.success };
            viewModal.Subscriber = new Subscriber();
            ModelState.Clear();

            return PartialView("_FormFields", viewModal);
        }
    }
}