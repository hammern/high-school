using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace School_Manager
{
    public partial class Form1 : Form
    {
        TeacherList teacherList =  new TeacherList();
        StudentsList studentList = new StudentsList();
        ClassList classList = new ClassList();
        StaffList staffList = new StaffList();
        SubjectList subjectList = new SubjectList();
        TestList testList = new TestList();
        GradeList gradeList = new GradeList();
        bool TeacherIsUpdating;
        bool StudentIsUpdating;
        bool ClassIsUpdating;
        bool StaffIsUpdating;
        bool Ascending = true;

        public Form1()
        {
            Font = SystemFonts.DialogFont;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(350, 410);
            Point point = new Point(12, 12);
            Default_Panel.Location = point;
            Teachers_Panel.Hide();
            Teachers_Panel.Location = point;
            Teacher_Panel.Hide();
            Teacher_Panel.Location = point;
            Students_Panel.Hide();
            Students_Panel.Location = point;
            Student_Panel.Hide();
            Student_Panel.Location = point;
            Classes_Panel.Hide();
            Classes_Panel.Location = point;
            Class_Panel.Hide();
            Class_Panel.Location = point;
            Staff_Panel.Hide();
            Staff_Panel.Location = point;
            StaffMember_Panel.Hide();
            StaffMember_Panel.Location = point;
            Subjects_Panel.Hide();
            Subjects_Panel.Location = point;
            Grades_Panel.Hide();
            Grades_Panel.Location = point;


            teacherList.Load();
            studentList.Load();
            classList.Load();
            staffList.Load();
            subjectList.Load();
            testList.Load();
            gradeList.Load();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //
        //
        // TEACHERS
        //
        //


        private void GoToTeachers_Click(object sender, EventArgs e)
        {
            Default_Panel.Hide();
            UpdateTeachersPanel();
            Teachers_Panel.Show();
        }

        private void UpdateTeachersPanel()
        {
            UpdateTeachersListView();
        }

        private void UpdateTeachersListView()
        {
            TeachersView.BeginUpdate();
            TeachersView.Items.Clear();
            for (int i = 0; i < teacherList.Length(); i++)
            {
                Teacher teacher = teacherList.GetTeacher(i);
                ListViewItem item = new ListViewItem(teacher.FirstName);
                item.SubItems.Add(teacher.LastName);
                item.SubItems.Add(teacher.ID);
                item.SubItems.Add(teacher.PayCheck);
                item.SubItems.Add(teacher.DateJoined);
                item.SubItems.Add(teacher.WeeklyHours);
                item.SubItems.Add(teacher.HomeRoomTeacher);
                item.SubItems.Add(String.Join(",", teacher.Subjects));

                TeachersView.Items.Add(item);
            }
            TeachersView.Columns[4].Width = -1;
            TeachersView.Columns[7].Width = -1;
            TeachersView.EndUpdate();
        }

        private void BackToDefaultFromTeachers_Click(object sender, EventArgs e)
        {
            Teachers_Panel.Hide();
            Default_Panel.Show();
        }

        private void BackToTeachersFromNewTeachers_Click(object sender, EventArgs e)
        {
            Teacher_Panel.Hide();
            UpdateTeachersPanel();
            Teachers_Panel.Show();
        }

        private void GoToNewTeacher_Click(object sender, EventArgs e)
        {
            Teachers_Panel.Hide();
            TeacherHeader.Text = "New Teacher";
            FirstName.Text = "";
            LastName.Text = "";
            ID.Text = "";
            PayCheck.Text = "";
            WeeklyHours.Text = "";
            HomeRoomTeacherText.Text = "";
            HomeRoomTeacherText.Items.Clear();
            HomeRoomTeacherText.Items.Add("None");
            for (int i = 0; i < classList.Length(); i++)
            {
                HomeRoomTeacherText.Items.Add(classList.GetClassRoom(i).ClassName);
            }
            TeachersSubjects.Items.Clear();
            for (int i = 0; i < subjectList.Length(); i++)
            {
                Subject subject = subjectList.GetSubject(i);
                TeachersSubjects.Items.Add(subject.Name);
            }
            EnterTeacher.Text = "Add";
            TeacherIsUpdating = false;
            Teacher_Panel.Show();
        }

        private void Enter_Teacher_Click(object sender, EventArgs e)
        {
            if (ValidateTeacher())
            {
                Teacher teacher = new Teacher();
                teacher.FirstName = FirstName.Text;
                teacher.LastName = LastName.Text;
                teacher.ID = ID.Text;
                teacher.PayCheck = PayCheck.Text;
                teacher.DateJoined = DateJoined.Text;
                teacher.WeeklyHours = WeeklyHours.Text;
                teacher.HomeRoomTeacher = HomeRoomTeacherText.Text;

                teacher.Subjects = new string[TeachersSubjects.CheckedItems.Count];
                for (int i = 0; i < teacher.Subjects.Length; i++)
                {
                    teacher.Subjects[i] = TeachersSubjects.CheckedItems[i].ToString();
                }

                if (HomeRoomTeacherText.Text == "None")
                {
                    teacher.HomeRoomTeacher = "None";
                }
                else
                {
                    teacher.HomeRoomTeacher = HomeRoomTeacherText.Text;
                }

                if (TeacherIsUpdating)
                {
                    ListViewItem item = TeachersView.SelectedItems[0];
                    teacherList.UpdateTeacher(item.Index, teacher);
                    Teacher_Panel.Hide();
                    Teachers_Panel.Show();
                }
                else
                {
                    teacherList.AddTeacher(teacher);

                    FirstName.Text = "";
                    LastName.Text = "";
                    ID.Text = "";
                    PayCheck.Text = "";
                    WeeklyHours.Text = "";
                    HomeRoomTeacherText.Text = "";
                    TeachersSubjects.Items.Clear();
                    Teacher_Panel.Hide();
                    Teachers_Panel.Show();
                }
                teacherList.Save();
                UpdateTeachersPanel();
            }
        }
        public bool ValidateTeacher()
        {
            if (!TeacherIsUpdating)
            {
                for (int i = 0; i < teacherList.Length(); i++)
                {
                    Teacher teacher = teacherList.GetTeacher(i);
                    if (teacher.FirstName == FirstName.Text && teacher.LastName == LastName.Text)
                    {
                        return false;
                    }
                    if (teacher.ID == ID.Text)
                    {
                        return false;
                    }
                }
            }
            if (FirstName.Text == "")
            {
                return false;
            }
            if (LastName.Text == "")
            {
                return false;
            }
            if (ID.Text == "")
            {
                return false;
            }
            if (PayCheck.Text == "")
            {
                return false;
            }
            if (WeeklyHours.Text == "")
            {
                return false;
            }
            if (HomeRoomTeacherText.Text == "")
            {
                return false;
            }
            if (TeachersSubjects.CheckedItems.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void DeleteTeacher_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in TeachersView.SelectedItems)
            {
                teacherList.RemoveTeacher(item.Index);
                TeachersView.Items.Remove(item);
            }
            teacherList.Save();
        }

        private void UpdateTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = TeachersView.SelectedItems[0];
                Teachers_Panel.Hide();
                TeacherHeader.Text = "Update Teacher";
                TeacherIsUpdating = true;
                UpdateTeacherPanel(teacherList.GetTeacher(item.Index));
                Teacher_Panel.Show();
            }
            catch
            {
                MessageBox.Show("Must select a teacher");
            }
        }
         
        private void UpdateTeacherPanel(Teacher teacher)
        {
            FirstName.Text = teacher.FirstName;
            LastName.Text = teacher.LastName;
            ID.Text = teacher.ID;
            PayCheck.Text = teacher.PayCheck;
            DateJoined.Text = teacher.DateJoined;
            WeeklyHours.Text = teacher.WeeklyHours;
            HomeRoomTeacherText.Items.Clear();
            HomeRoomTeacherText.Items.Add("None");
            for (int i = 0; i < classList.Length(); i++)
            {
                HomeRoomTeacherText.Items.Add(classList.GetClassRoom(i).ClassName);
            }
            HomeRoomTeacherText.SelectedItem = teacher.HomeRoomTeacher;
            TeachersSubjects.Items.Clear();
            for (int i = 0; i < subjectList.Length(); i++)
            {
                Subject subject = subjectList.GetSubject(i);
                TeachersSubjects.Items.Add(subject.Name);
            }
            for (int i = 0; i < teacher.Subjects.Length; i++)
            {
                for (int j = 0; j < subjectList.Length(); j++)
                {
                    if (teacher.Subjects[i] == subjectList.GetSubject(j).Name)
                    {
                        TeachersSubjects.SetItemChecked(i, true);
                    }
                }
            }
            EnterTeacher.Text = "Update";
        }

        private void TeachersView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Ascending = !Ascending;
            if (e.Column == 0)
            {
                teacherList.SortByName(Ascending);
            }
            else if (e.Column == 1)
            {
                teacherList.SortByLastName(Ascending);
            }
            else if (e.Column == 2)
            {
                teacherList.SortByID(Ascending);
            }

            UpdateTeachersListView();
        }


        //
        //
        // Classes
        //
        //

        
        private void GoToClasses_Click(object sender, EventArgs e)
        {
            Default_Panel.Hide();
            UpdateClassesPanel();
            Classes_Panel.Show();
        }

        private void UpdateClassesPanel()
        {
            UpdateClassesListView();
        }

        private void UpdateClassesListView()
        {
            ClassView.BeginUpdate();
            ClassView.Items.Clear();
            for (int i = 0; i < classList.Length(); i++)
            {
                ClassRoom classRoom = classList.GetClassRoom(i);
                ListViewItem item = new ListViewItem(classRoom.ClassName);
                Teacher teacher = teacherList.GetHomeRoomTeacher(classRoom);
                string teacherName = "";
                if (teacher != null)
                {
                    teacherName = String.Format("{0} {1}", teacher.FirstName, teacher.LastName);
                }
                else
                {
                    teacherName = "None";
                }
                item.SubItems.Add(teacherName);
                classRoom.NumOfStudents = studentList.GetNumOfStudents(classRoom);
                item.SubItems.Add(classRoom.NumOfStudents);

                ClassView.Items.Add(item);
            }
            ClassView.EndUpdate();
        }

        private void BackToDefaultFromClasses_Click(object sender, EventArgs e)
        {
            Classes_Panel.Hide();
            Default_Panel.Show();
        }

        private void GoToNewClass_Click(object sender, EventArgs e)
        {
            Classes_Panel.Hide();
            ClassHeader.Text = "New Class";
            ClassText.Text = "";
            HomeRoomTeacherLabel.Text = "None";
            string[] AllStudents = new string[studentList.Length()];
            bool HaveStudents = false;
            int count = 0;
            for (int i = 0; i < studentList.Length(); i++)
            {
                Student student = studentList.GetStudent(i);
                if (student.Class == "None")
                {
                    HaveStudents = true;
                    AllStudents[i] = String.Format("{0} {1}", student.FirstName, student.LastName);
                    count++;
                }
            }
            StudentsCheck.Items.Clear();
            if (HaveStudents)
            {
                for (int i = 0; i < AllStudents.Length; i++)
                {
                    if (AllStudents[i] != null)
                    {
                        StudentsCheck.Items.Add(AllStudents[i]);
                    }
                }
            }
            EnterClass.Text = "Add";
            ClassIsUpdating = false;
            Class_Panel.Show();
        }

        private void BackToClassesFromNewClass_Click(object sender, EventArgs e)
        {
            Class_Panel.Hide();
            UpdateClassesPanel();
            Classes_Panel.Show();
        }

        private void EnterClass_Click(object sender, EventArgs e)
        {
            if (ValidateClass())
            {
                ClassRoom classRoom = new ClassRoom();
                classRoom.ClassName = ClassText.Text;

                if (ClassIsUpdating)
                {
                    string OldClass = classRoom.ClassName;
                    for (int i = 0; i < teacherList.Length(); i++)
                    {
                        Teacher teacher = teacherList.GetTeacher(i);
                        if (teacher.HomeRoomTeacher == OldClass)
                        {
                            teacher.HomeRoomTeacher = classRoom.ClassName;
                            break;
                        }
                    }
                    for (int i = 0; i < StudentsCheck.Items.Count; i++)
                    {
                        Student student = studentList.GetStudentByName(StudentsCheck.Items[i].ToString());
                        if (student != null)
                        {
                            if (StudentsCheck.GetItemCheckState(i) == CheckState.Checked)
                            {
                                student.Class = classRoom.ClassName;
                            }
                            else
                            {
                                student.Class = "None";
                            }
                            studentList.UpdateStudent(student);
                        }
                    }
                    ListViewItem item = ClassView.SelectedItems[0];
                    classRoom.NumOfStudents = studentList.GetNumOfStudents(classRoom);
                    classList.UpdateClass(item.Index, classRoom);
                    studentList.Save();
                    classList.Save();
                    Class_Panel.Hide();
                    Classes_Panel.Show();
                }
                else
                {
                    classRoom.NumOfStudents = "0";
                    classList.AddClass(classRoom);

                    ClassText.Text = "";
                    HomeRoomTeacherText.Text = "";
                    StudentsCheck.Items.Clear();
                    Teacher_Panel.Hide();
                    Teachers_Panel.Show();
                }
                classList.Save();
                UpdateClassesPanel();
            }
        }

        public bool ValidateClass()
        {
            if (!ClassIsUpdating)
            {
                for (int i = 0; i < classList.Length(); i++)
                {
                    ClassRoom classRoom = classList.GetClassRoom(i);
                    if (classRoom.ClassName == Class.Text)
                    {
                        return false;
                    }
                }
            }
            if (ClassText.Text.IndexOf("-") < 0)
            {
                MessageBox.Show("Wrong Format!\nNeeds to be Grade-ClassNumber\nFor example: 10-3 simulates" +
                    " the third tenth grade");
                return false;
            }
            if (ClassText.Text == "")
            {
                return false;
            }
            return true;
        }

        private void DeleteClass_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ClassView.SelectedItems)
            {
                classList.RemoveClass(item.Index);
                ClassView.Items.Remove(item);
            }
            classList.Save();
        }

        private void UpdateClass_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = ClassView.SelectedItems[0];
                Classes_Panel.Hide();
                ClassHeader.Text = "Update Class";
                ClassIsUpdating = true;
                UpdateClassPanel(classList.GetClassRoom(item.Index));
                Class_Panel.Show();
            }
            catch
            {
                MessageBox.Show("Must select a class");
            }
        }

        private void UpdateClassPanel(ClassRoom classRoom)
        {
            ClassText.Text = classRoom.ClassName;
            Teacher teacher = teacherList.GetHomeRoomTeacher(classRoom);
            if (teacher != null)
            {
                HomeRoomTeacherLabel.Text = String.Format("{0} {1}", teacher.FirstName, teacher.LastName);
            }
            else
            {
                HomeRoomTeacherLabel.Text = "None";
            }
            StudentsCheck.Items.Clear();
            int count = 0;
            for (int i = 0; i < studentList.Length(); i++)
            {
                Student student = studentList.GetStudent(i);
                if (student.Class == classRoom.ClassName)
                {
                    StudentsCheck.Items.Add(String.Format("{0} {1}", student.FirstName, student.LastName));
                    StudentsCheck.SetItemChecked(count, student.Class == classRoom.ClassName);
                    count++;
                }
                else if (student.Class == "None")
                {
                    StudentsCheck.Items.Add(String.Format("{0} {1}", student.FirstName, student.LastName));
                    count++;
                }
            }
            EnterClass.Text = "Update";
        }


        //
        //
        // STUDENTS
        //
        //


        private void GoToStudents_Click(object sender, EventArgs e)
        {
            Default_Panel.Hide();
            UpdateStudentsPanel();
            Students_Panel.Show();
        }

        private void BackToDefaultFromStudents_Click(object sender, EventArgs e)
        {
            Students_Panel.Hide();
            Default_Panel.Show();
        }

        private void BackToStudentsFromNewStudent_Click(object sender, EventArgs e)
        {
            Student_Panel.Hide();
            UpdateStudentsPanel();
            Students_Panel.Show();
        }

        private void UpdateStudentsPanel()
        {
            UpdateStudentsListView();
        }

        private void UpdateStudentsListView()
        {
            StudentsView.BeginUpdate();
            StudentsView.Items.Clear();

            for (int i = 0; i < studentList.Length(); i++)
            {
                Student student = studentList.GetStudent(i);
                ListViewItem item = new ListViewItem(student.FirstName);
                item.SubItems.Add(student.LastName);
                item.SubItems.Add(student.ID);
                item.SubItems.Add(student.Class);
                item.SubItems.Add(student.Major);
                item.SubItems.Add(String.Join(",", student.Subjects));

                StudentsView.Items.Add(item);
            }
            StudentsView.Columns[4].Width = -1;
            StudentsView.Columns[5].Width = -1;
            StudentsView.EndUpdate();
        }

        private void GoToNewStudent_Click(object sender, EventArgs e)
        {
            Students_Panel.Hide();
            StudentHeader.Text = "New Student";
            SFirstName.Text = "";
            SLastName.Text = "";
            SID.Text = "";
            Class.Text = "";
            Class.Items.Clear();
            Class.Items.Add("None");
            for (int i = 0; i < classList.Length(); i++)
            {
                Class.Items.Add(classList.GetClassRoom(i).ClassName);
            }
            Major.Text = "";
            Major.Items.Clear();
            Major.Items.Add("None");
            StudentsSubjects.Items.Clear();
            for (int i = 0; i < subjectList.Length(); i++)
            {
                Subject subject = subjectList.GetSubject(i);
                if (subject.IsMajor)
                {
                    Major.Items.Add(subject.Name);
                }
                else
                {
                    StudentsSubjects.Items.Add(subject.Name);
                }
            }
            EnterStudent.Text = "Add";
            StudentIsUpdating = false;
            Student_Panel.Show();
        }

        private void EnterStudent_Click(object sender, EventArgs e)
        {
            if (ValidateStudent())
            {
                Student student = new Student();
                student.FirstName = SFirstName.Text;
                student.LastName = SLastName.Text;
                student.ID = SID.Text;
                student.Class = Class.Text;
                student.Major = Major.Text;
                student.Subjects = new string[StudentsSubjects.CheckedItems.Count];
                for (int i = 0; i < student.Subjects.Length; i++)
                {
                    student.Subjects[i] = StudentsSubjects.CheckedItems[i].ToString();
                }
                if (StudentIsUpdating)
                {
                    ListViewItem item = StudentsView.SelectedItems[0];
                    studentList.UpdateStudent(item.Index, student);
                    Student_Panel.Hide();
                    Students_Panel.Show();
                }
                else
                {
                    studentList.AddStudent(student);

                    SFirstName.Text = "";
                    SLastName.Text = "";
                    SID.Text = "";
                    Class.Text = "";
                    Major.Text = "";
                    StudentsSubjects.Items.Clear();
                    Student_Panel.Hide();
                    Students_Panel.Show();
                }
                studentList.Save();
                UpdateStudentsPanel();
            }
        }

        public bool ValidateStudent()
        {
            if (!StudentIsUpdating)
            {
                for (int i = 0; i < studentList.Length(); i++)
                {
                    Student student = studentList.GetStudent(i);
                    if (student.FirstName == SFirstName.Text && student.LastName == SLastName.Text)
                    {
                        return false;
                    }
                    if (student.ID == SID.Text)
                    {
                        return false;
                    }
                }
            }
            if (SFirstName.Text == "")
            {
                return false;
            }
            if (SLastName.Text == "")
            {
                return false;
            }
            if (SID.Text == "")
            {
                return false;
            }
            if (Class.Text == "")
            {
                return false;
            }
            if (Major.Text == "")
            {
                return false;
            }
            if (StudentsSubjects.CheckedItems.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void DeleteStudent_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in StudentsView.SelectedItems)
            {
                studentList.RemoveStudent(item.Index);
                StudentsView.Items.Remove(item);
            }
            studentList.Save();
        }

        private void UpdateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = StudentsView.SelectedItems[0];
                Students_Panel.Hide();
                StudentHeader.Text = "Update Student";
                StudentIsUpdating = true;
                UpdateStudentPanel(studentList.GetStudent(item.Index));
                Student_Panel.Show();
            }
            catch
            {
                MessageBox.Show("Must select a student");
            }
        }
        private void UpdateStudentPanel(Student student)
        {
            SFirstName.Text = student.FirstName;
            SLastName.Text = student.LastName;
            SID.Text = student.ID;

            Class.Items.Clear();
            Class.Items.Add("None");
            for (int i = 0; i < classList.Length(); i++)
            {
                Class.Items.Add(classList.GetClassRoom(i).ClassName);
            }
            Major.Text = "";
            Major.Items.Clear();
            Major.Items.Add("None");
            StudentsSubjects.Items.Clear();
            for (int i = 0; i < subjectList.Length(); i++)
            {
                Subject subject = subjectList.GetSubject(i);
                if (subject.IsMajor)
                {
                    Major.Items.Add(subject.Name);
                }
                else
                {
                    StudentsSubjects.Items.Add(subject.Name);
                }
            }
            for (int i = 0; i < student.Subjects.Length; i++)
            {
                for (int j = 0; j < subjectList.Length(); j++)
                {
                    if (student.Subjects[i] == subjectList.GetSubject(j).Name)
                    {
                        StudentsSubjects.SetItemChecked(i, true);
                    }
                }
            }
            Class.SelectedItem = student.Class;
            Major.SelectedItem = student.Major;
            EnterStudent.Text = "Update";
        }

        private void StudentsView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Ascending = !Ascending;
            if (e.Column == 0)
            {
                studentList.SortByName(Ascending);
            }
            else if (e.Column == 1)
            {
                studentList.SortByLastName(Ascending);
            }
            else if (e.Column == 2)
            {
                studentList.SortByID(Ascending);
            }

            UpdateStudentsListView();
        }


        //
        //
        // STAFF
        //
        //

        
        private void GoToStaff_Click(object sender, EventArgs e)
        {
            Default_Panel.Hide();
            UpdateStaffPanel();
            Staff_Panel.Show();
        }

        private void BackToDefaultFromStaff_Click(object sender, EventArgs e)
        {
            Staff_Panel.Hide();
            Default_Panel.Show();
        }

        private void UpdateStaffPanel()
        {
            UpdateStaffListView();
        }

        private void UpdateStaffListView()
        {
            StaffView.BeginUpdate();
            StaffView.Items.Clear();
            for (int i = 0; i < staffList.Length(); i++)
            {
                Staff staff = staffList.GetStaff(i);
                ListViewItem item = new ListViewItem(staff.FirstName);
                item.SubItems.Add(staff.LastName);
                item.SubItems.Add(staff.ID);
                item.SubItems.Add(staff.PayCheck);
                item.SubItems.Add(staff.DateJoined);
                item.SubItems.Add(staff.WeeklyHours);
                item.SubItems.Add(staff.Role);

                StaffView.Items.Add(item);
            }
            StaffView.EndUpdate();
        }

        private void GoToNewStaffMember_Click(object sender, EventArgs e)
        {
            Staff_Panel.Hide();
            StaffHeader.Text = "New Staff";
            SMFirstName.Text = "";
            SMLastName.Text = "";
            SMID.Text = "";
            SMPayCheck.Text = "";
            SMWeeklyHours.Text = "";
            StaffRole.Text = "";
            StaffRole.Items.Clear();
            StaffRole.Items.Add("None");
            string[] Roles = File.ReadAllLines("StaffRoles.txt");
            StaffRole.Items.AddRange(Roles);
            EnterStaff.Text = "Add";
            StaffIsUpdating = false;
            StaffMember_Panel.Show();
        }

        private void DeleteStaffMember_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in StaffView.SelectedItems)
            {
                staffList.RemoveStaff(item.Index);
                StaffView.Items.Remove(item);
            }
            staffList.Save();
        }

        private void UpdateStaffMember_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = StaffView.SelectedItems[0];
                Staff_Panel.Hide();
                StaffHeader.Text = "Update Staff";
                StaffIsUpdating = true;
                UpdateStaffPanel(staffList.GetStaff(item.Index));
                StaffMember_Panel.Show();
            }
            catch
            {
                MessageBox.Show("Must select a staff member");
            }
        }

        private void UpdateStaffPanel(Staff staff)
        {
            SMFirstName.Text = staff.FirstName;
            SMLastName.Text = staff.LastName;
            SMID.Text = staff.ID;
            SMPayCheck.Text = staff.PayCheck;
            SMDateJoined.Text = staff.DateJoined;
            SMWeeklyHours.Text = staff.WeeklyHours;
            StaffRole.Items.Clear();
            StaffRole.Items.Add("None");
            string[] Roles = File.ReadAllLines("StaffRoles.txt");
            StaffRole.Items.AddRange(Roles);
            StaffRole.SelectedItem = staff.Role;
            EnterStaff.Text = "Update";
        }

        private void BackToStaffFromStaffMember_Click(object sender, EventArgs e)
        {
            StaffMember_Panel.Hide();
            UpdateStaffPanel();
            Staff_Panel.Show();
        }

        private void EnterStaff_Click(object sender, EventArgs e)
        {
            if (ValidateStaff())
            {
                Staff staff = new Staff();
                staff.FirstName = SMFirstName.Text;
                staff.LastName = SMLastName.Text;
                staff.ID = SMID.Text;
                staff.PayCheck = SMPayCheck.Text;
                staff.DateJoined = SMDateJoined.Text;
                staff.WeeklyHours = SMWeeklyHours.Text;

                if (StaffRole.Text == "None")
                {
                    staff.Role = "None";
                }
                else
                {
                    staff.Role = StaffRole.Text;
                }

                if (StaffIsUpdating)
                {
                    ListViewItem item = StaffView.SelectedItems[0];
                    staffList.UpdateStaff(item.Index, staff);
                    StaffMember_Panel.Hide();
                    Staff_Panel.Show();
                }
                else
                {
                    staffList.AddStaff(staff);

                    SMFirstName.Text = "";
                    SMLastName.Text = "";
                    SMID.Text = "";
                    SMPayCheck.Text = "";
                    SMWeeklyHours.Text = "";
                    StaffRole.Text = "";
                    StaffMember_Panel.Hide();
                    Staff_Panel.Show();
                }
                staffList.Save();
                UpdateStaffPanel();
            }
        }

        public bool ValidateStaff()
        {
            if (!StaffIsUpdating)
            {
                for (int i = 0; i < staffList.Length(); i++)
                {
                    Staff staff = staffList.GetStaff(i);
                    if (staff.FirstName == SMFirstName.Text && staff.LastName == SMLastName.Text)
                    {
                        return false;
                    }
                    if (staff.ID == SMID.Text)
                    {
                        return false;
                    }
                }
            }
            if (SMFirstName.Text == "")
            {
                return false;
            }
            if (SMLastName.Text == "")
            {
                return false;
            }
            if (SMID.Text == "")
            {
                return false;
            }
            if (SMPayCheck.Text == "")
            {
                return false;
            }
            if (SMWeeklyHours.Text == "")
            {
                return false;
            }
            if (StaffRole.Text == "")
            {
                return false;
            }
            return true;
        }


        //
        //
        // SUBJECTS, MAJORS AND TESTS
        //
        //


        private void GoToSubjectsAndMajors_Click(object sender, EventArgs e)
        {
            Default_Panel.Hide();
            SubjectsView.CheckBoxes = true;
            SubjectsView.Columns[1].Width = 100;
            UpdateSubjectsPanel();
            Subjects_Panel.Show();
        }

        private void BackToDefaultFromSubjects_Click(object sender, EventArgs e)
        {
            Default_Panel.Show();
            Subjects_Panel.Hide();
        }

        private void UpdateSubjectsPanel()
        {
            UpdateSubjectsListView();
        }

        private void UpdateSubjectsListView()
        {
            SubjectsView.BeginUpdate();
            SubjectsView.Items.Clear();
            for (int i = 0; i < subjectList.Length(); i++)
            {
                Subject subject = subjectList.GetSubject(i);
                ListViewItem item = new ListViewItem(subject.Name);
                item.SubItems.Add(subject.NumOfHours);

                SubjectsView.Items.Add(item);
                if (subject.IsMajor == true)
                {
                    item.Checked = true;
                }
            }
            SubjectsView.EndUpdate();
        }

        private void UpdateTestsListView()
        {
            TestsView.BeginUpdate();
            TestsView.Items.Clear();
            ListViewItem testData = SubjectsView.SelectedItems[0];
            for (int i = 0; i < testList.Length(); i++)
            {
                Test test = testList.GetTest(i);
                if (test.SubjectName == testData.Text)
                {
                    ListViewItem item = new ListViewItem(test.SubjectName);
                    item.SubItems.Add(test.Date);

                    TestsView.Items.Add(item);
                }
            }
            testList.SortByDate();
            TestsView.EndUpdate();
        }

        private void SubjectsView_ItemActivate(object sender, EventArgs e)
        {
            UpdateTestsListView();
        }

        private void AddSubject_Click(object sender, EventArgs e)
        {
            if (ValidateSubject())
            {
                Subject subject = new Subject();
                subject.Name = NewSubject.Text;
                subject.NumOfHours = SubjectHours.Text;
                subject.IsMajor = IsMajor.Checked;

                subjectList.AddSubject(subject);
                NewSubject.Text = "";
                SubjectHours.Text = "";
                IsMajor.Checked = false;

                subjectList.Save();
                UpdateSubjectsPanel();
            }
        }

        private bool ValidateSubject()
        {
            for (int i = 0; i < subjectList.Length(); i++)
            {
                Subject subject = subjectList.GetSubject(i);
                if (subject.Name == NewSubject.Text)
                {
                    return false;
                }
            }
            if (NewSubject.Text == "")
            {
                return false;
            }
            if (SubjectHours.Text == "")
            {
                return false;
            }
            return true;
        }

        private void DeleteSubject_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in SubjectsView.SelectedItems)
            {
                subjectList.RemoveSubject(item.Index);
                SubjectsView.Items.Remove(item);
            }
            subjectList.Save();
        }

        private void AddTest_Click(object sender, EventArgs e)
        {
            if (SubjectsView.SelectedItems.Count > 0)
            {
                if (ValidateTest())
                {
                    Test test = new Test();
                    ListViewItem item = SubjectsView.SelectedItems[0];
                    test.SubjectName = item.Text;
                    test.Date = TestDate.Text;

                    testList.AddTest(test);

                    testList.Save();
                    UpdateTestsListView();
                }
            }
            else
            {
                MessageBox.Show("Must select a subject");
            }
        }

        private bool ValidateTest()
        {
            ListViewItem item = SubjectsView.SelectedItems[0];
            string testDate = TestDate.Text;
            for (int i = 0; i < testList.Length(); i++)
            {
                Test test = testList.GetTest(i);
                if (test.SubjectName == item.Text && test.Date == testDate)
                {
                    return false;
                }
            }
            return true;
        }

        private void DeleteTest_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in TestsView.SelectedItems)
            {
                testList.RemoveTest(item.Index);
                TestsView.Items.Remove(item);
            }
            testList.Save();
        }

        //
        //
        // TEST RESULTS
        //
        //

        
        private void GoToGrades_Click(object sender, EventArgs e)
        {
            Subjects_Panel.Hide();
            Tests.Text = "";
            Tests.Items.Clear();
            testList.SortBySubject();
            string[] AllTests = new string[testList.Length()];
            for (int i = 0; i < testList.Length(); i++)
            {
                Test test = testList.GetTest(i);
                AllTests[i] = String.Format("{0},{1}", test.SubjectName, test.Date);
            }
            Tests.Items.AddRange(AllTests);
            Grades_Panel.Show();
        }

        private void BackToSubjectsFromGrades_Click(object sender, EventArgs e)
        {
            Grades_Panel.Hide();
            Subjects_Panel.Show();
        }

        private void Tests_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGradesPanel();
        }

        private void UpdateGradesPanel()
        {
            UpdateGradesListView();
        }

        private void UpdateGradesListView()
        {
            GradesView.BeginUpdate();
            GradesView.Items.Clear();
            TestStudents.Items.Clear();
            Grade.Text = "";
            for (int i = 0; i < gradeList.Length(); i++)
            {
                Grade grade = gradeList.GetGrade(i);
                if (String.Format("{0},{1}", grade.TestSubject, grade.TestDate) == Tests.SelectedItem.ToString())
                {
                    ListViewItem item = new ListViewItem(grade.Student);
                    item.SubItems.Add(grade.Score.ToString());

                    GradesView.Items.Add(item);
                }
            }
            for (int i = 0; i < studentList.Length(); i++)
            {
                Student student = studentList.GetStudent(i);
                foreach (string subject in student.Subjects)
                {
                    if (Tests.SelectedItem.ToString().Split(',')[0] == subject)
                    {
                        TestStudents.Items.Add(String.Format("{0} {1}", student.FirstName, student.LastName));
                        break;
                    }
                }
                if (Tests.SelectedItem.ToString().Split(',')[0] == student.Major)
                {
                    TestStudents.Items.Add(String.Format("{0} {1}", student.FirstName, student.LastName));
                    break;
                }
            }
            GradesView.EndUpdate();
            int Avg = 0;
            int Count = 0;
            for (int i = 0; i < gradeList.Length(); i++)
            {
                Grade grade = gradeList.GetGrade(i);
                if (String.Format("{0},{1}", grade.TestSubject, grade.TestDate) == Tests.SelectedItem.ToString())
                {
                    Avg += grade.Score;
                    Count++;
                }
            }
            if (Count > 0)
            {
                Avg /= Count;
            }
            AvgLabel.Text = "Average is: " + Avg.ToString();
        }

        private void UpdateGrade_Click(object sender, EventArgs e)
        {
            if (ValidateGrade())
            {
                Grade grade = new Grade();
                grade.TestSubject = Tests.SelectedItem.ToString().Split(',')[0];
                grade.TestDate = Tests.SelectedItem.ToString().Split(',')[1];
                grade.Student = TestStudents.SelectedItem.ToString();
                grade.Score = int.Parse(Grade.Text);

                int i = gradeList.FindGrade(grade);
                if (i >= 0)
                {
                    gradeList.UpdateGrade(i, grade);
                }
                else
                {
                    gradeList.AddGrade(grade);
                }

                Grade.Text = "";
                gradeList.Save();
                UpdateGradesPanel();
            }
        }

        private bool ValidateGrade()
        {
            if (Tests.Text == "")
            {
                return false;
            }
            if (TestStudents.Text == "")
            {
                return false;
            }
            if (Grade.Text == "")
            {
                return false;
            }
            return true;
        }

        private void TestStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gradeList.Length(); i++)
            {
                Grade grade = gradeList.GetGrade(i);
                if (grade.Student == TestStudents.SelectedItem.ToString() &&
                    String.Format("{0},{1}", grade.TestSubject, grade.TestDate) == Tests.SelectedItem.ToString())
                {
                    Grade.Text = grade.Score.ToString();
                    break;
                }
            }
            if (Grade.Text == "")
            {
                Grade.Text = "0";
            }
        }
    }
}
