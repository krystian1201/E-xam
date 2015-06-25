
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamDomain.Model;
using Shared.Repository;

namespace E_xam.MVCWebUI.Controllers
{

    [Authorize(Roles = "Teacher")]
    public class QuestionsController : Controller
    {
        
        private readonly IRepository<Question> _questionsRepository;
        private readonly IRepository<ClosedAnswer> _closedAnswersRepository; 

        public QuestionsController()
        {
            var dbContext = new ApplicationDbContext();

            _questionsRepository = new Repository<Question>(dbContext);
            _closedAnswersRepository = new Repository<ClosedAnswer>(dbContext);
        }


        //GET: Questions/_ClosedQuestionPartial
        public ActionResult _ClosedQuestionPartial()
        {
             return PartialView();
        }


        //GET: Questions/_ClosedQuestionAnswersPartial
        public ActionResult _ClosedQuestionAnswersPartial(int numberOfAnswers)
        {
            ViewBag.numberOfAnswers = numberOfAnswers;

            return PartialView();
        }


        // GET: Questions

        public ActionResult Index()
        {
            
            return View(_questionsRepository.GetAll());
        }


        // GET: Questions/Details/5
        [Route("Question/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = _questionsRepository.GetById(id.Value);
            if (question == null)
            {
                return HttpNotFound();
            }

            ClosedQuestion closedQuestion = question as ClosedQuestion;
            if (closedQuestion != null)
            {
                closedQuestion.AnswerChoices = _closedAnswersRepository.Find(a => a.ClosedQuestionID == closedQuestion.ID).ToList();

                //return View("ClosedQuestionDetails", closedQuestion);
                return View(closedQuestion);
            }

            return View(question);
        }


        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TimeToRespond,Text,Points,AnswerChoices")] ClosedQuestion question)
        {
            if (ModelState.IsValid)
            {
                _questionsRepository.Add(question);


                //closed question
                if (question != null && question.AnswerChoices != null)
                {
                    foreach (var answerChoice in question.AnswerChoices)
                    {
                        answerChoice.ClosedQuestionID = question.ID;
                    }

                }

                return RedirectToAction("Index");
            }

            return View(question);
        }


        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = _questionsRepository.GetById(id.Value);

            if (question == null)
            {
                return HttpNotFound();
            }

            ClosedQuestion closedQuestion = question as ClosedQuestion;
            if (closedQuestion != null)
            {
                closedQuestion.AnswerChoices = _closedAnswersRepository.Find(a => a.ClosedQuestionID == closedQuestion.ID).ToList();

                //ViewBag.AnswerChoices = closedQuestion.AnswerChoices;

                return View(closedQuestion);    
            }

            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TimeToRespond,Text,Points,AnswerChoices,ExamID")] ClosedQuestion question)
        {

            if (ModelState.IsValid)
            {

                //ClosedQuestion question = justQuestion as ClosedQuestion;
                if (question != null && question.AnswerChoices != null)
                {
                    foreach (var answerChoice in question.AnswerChoices)
                    {
                        if (answerChoice.ToBeDeleted)
                        {
                            _closedAnswersRepository.Delete(answerChoice);
                        }
                        //added answer choice
                        else if(answerChoice.ID == 0)
                        {
                             answerChoice.ClosedQuestionID = question.ID;
                            _closedAnswersRepository.Add(answerChoice);
                        }
                        //updated answer choice
                        else
                        {
                            _closedAnswersRepository.Update(answerChoice); 
                        }   
                    }
                }

                _questionsRepository.Update(question);

                //some answer choices may have been removed so
                //need to be "refreshed" from db
                question.AnswerChoices = 
                    _closedAnswersRepository.Find(a => a.ClosedQuestionID == question.ID).ToList();

                return View("Details", question);
            }

            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = _questionsRepository.GetById(id.Value);

            if (question == null)
            {
                return HttpNotFound();
            }

            ClosedQuestion closedQuestion = question as ClosedQuestion;
            if (closedQuestion != null)
            {
                closedQuestion.AnswerChoices = _closedAnswersRepository.Find(a => a.ClosedQuestionID == closedQuestion.ID).ToList();

                //return View("ClosedQuestionDetails", closedQuestion);
                return View(closedQuestion);
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            //ClosedQuestion question = _questionsRepository.GetById(id)

            _questionsRepository.Delete(id);
            _closedAnswersRepository.DeleteWhere(a => a.ClosedQuestionID == id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _questionsRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}
