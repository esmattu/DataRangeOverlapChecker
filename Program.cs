using System;
using System.Collections.Generic;

namespace DataRangeOverlapChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //set up test dates
            List<CourseIntiative> courseIntiatives = new List<CourseIntiative>();
            courseIntiatives.Add(new CourseIntiative
            {
                Intiative = "03",
                StartDate = new DateTime(2021, 07, 01),
                EndDate = new DateTime(2021, 08, 01)
            });
            courseIntiatives.Add(new CourseIntiative {
                Intiative = "01",
                StartDate = new DateTime(2021, 01, 01),
                EndDate = new DateTime(2021, 06, 01)
            });
            // overlap with 01
            courseIntiatives.Add(new CourseIntiative
            {
                Intiative = "02",
                StartDate = new DateTime(2021, 01, 01),
                EndDate = new DateTime(2021, 03, 01)
            });
            // No overlap



            CourseIntiative recursiveCheckDateOverlap (List<CourseIntiative> listOfCourseIntiatives, CourseIntiative currnetIntiative = null, int count = 0) {

                //set the first date to check
                if (currnetIntiative == null)
                {
                   return recursiveCheckDateOverlap(listOfCourseIntiatives, listOfCourseIntiatives[count]);
                }

                //check count is not greater than the course list length
                if (count > listOfCourseIntiatives.Count){
                    return new CourseIntiative();
                }

                var shiftIndex = count + 1;
                var startA = currnetIntiative.StartDate;
                var endA = currnetIntiative.EndDate;
                var startB = listOfCourseIntiatives[shiftIndex].StartDate;
                var endB = listOfCourseIntiatives[shiftIndex].EndDate;

                if ((startA == null || endB == null || startA <= endB) && (endA == null || startB == null || endA >= startB)) {

                    return currnetIntiative;
                } else
                {
                    
                    currnetIntiative = listOfCourseIntiatives[shiftIndex];
                    count++;
                    recursiveCheckDateOverlap(listOfCourseIntiatives, currnetIntiative, count);
                }

                return new CourseIntiative();
            }

            CourseIntiative overlappingCourseIntiative = recursiveCheckDateOverlap(courseIntiatives);

            Console.WriteLine("The course that is overlapping is " + overlappingCourseIntiative.Intiative 
                + " Start Date: " + overlappingCourseIntiative.StartDate.ToString() 
                + " End Date: " + overlappingCourseIntiative.EndDate.ToString());

            Console.WriteLine("Hello World!");



        }


    }

    class CourseIntiative
    {
        public string Intiative { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }
    }



}
