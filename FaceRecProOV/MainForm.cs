using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data;
using EntityLayer;
using DataLayer.DataHelper;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;


        public FrmPrincipal()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }

        string sql, speciality;
        int ssn;
        DoctorHelper docHelper = new DoctorHelper();
        PractiontinarHelper prHelper = new PractiontinarHelper();
        private void button2_Click(object sender, System.EventArgs e)
        {
            //Save user details in Database


            User usr = new User();
            usr.Email = txtEmail.Text;
            usr.Name = txtName.Text;
            usr.Password = txtPassword.Text;
            usr.Username = txtUserName.Text;
            usr.Speciality = txtSpeciality.Text;

            if (drpUserType.SelectedItem.Equals("Doctor"))
            {
                usr.UserType = "D";
                bool isAdded = docHelper.RegisterDoctor(usr);
                if (isAdded)
                {
                    EnrollFace();
                    MessageBox.Show("Doctor saved successfully");
                }
                else
                {
                    MessageBox.Show("Some error occured.");
                }
            }
            else
                if (drpUserType.SelectedItem.Equals("Physician"))
                {
                    usr.UserType = "M";
                    bool isAdded = prHelper.RegisterPractioner(usr);
                    if (isAdded)
                    {
                        EnrollFace();
                        MessageBox.Show("Physician saved successfully");
                    }
                    else
                    {
                        MessageBox.Show("Some error occured.");
                    }
                }
                else
                    if (drpUserType.SelectedItem.Equals("Nurse"))
                    {
                        usr.UserType = "N";
                        bool isAdded = prHelper.RegisterPractioner(usr);
                        if (isAdded)
                        {
                            EnrollFace();
                            MessageBox.Show("Nurse saved successfully");
                        }
                        else
                        {
                            MessageBox.Show("Some error occured.");
                        }
                    }


            //try
            //{
            //    ssn = Convert.ToInt32(txtSSN.Text);
            //    string name = txtName.Text;
            //    string sex = cmbSex.SelectedText;
            //    int age = Convert.ToInt16(txtPassword.Text);
            //    string address = txtAddress.Text;
            //    long phone = Convert.ToInt64(txtUserName.Text);


            //    sql = "insert into employees values(" + ssn + ",'" + name + "','" + sex + "'," + age + ",'" + address + "'," + phone + ",1);";
            //    DataTable results = new DataTable();
            //    using (MySqlConnection con = DBConnector.OpenConnection())
            //    {
            //        try
            //        {
            //            con.Open();
            //        }
            //        catch (Exception)
            //        { }
            //        using (MySqlCommand comm = new MySqlCommand(sql, con))
            //        {
            //            try
            //            {
            //                results.Load(comm.ExecuteReader());
            //                try
            //                {
            //                    //Trained face counter
            //                    ContTrain = ContTrain + 1;

            //                    //Get a gray frame from capture device
            //                    gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //                    //Face Detector
            //                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
            //                    face,
            //                    1.2,
            //                    10,
            //                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
            //                    new Size(20, 20));

            //                    //Action for each element detected
            //                    foreach (MCvAvgComp f in facesDetected[0])
            //                    {
            //                        TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
            //                        break;
            //                    }

            //                    //resize face detected image for force to compare the same size with the 
            //                    //test image with cubic interpolation type method
            //                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //                    trainingImages.Add(TrainedFace);
            //                    labels.Add(txtName.Text);

            //                    //Show face added in gray scale
            //                    imageBox1.Image = TrainedFace;

            //                    //Write the number of triained faces in a file text for further load
            //                    File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

            //                    //Write the labels of triained faces in a file text for further load
            //                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
            //                    {
            //                        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
            //                        File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
            //                    }

            //                    MessageBox.Show(txtName.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }
            //                catch
            //                {
            //                    MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                }
            //                MessageBox.Show("Employee registered successfully");
            //            }
            //            catch (Exception ex)
            //            {
            //                string except = ex.Message.ToString();
            //                except = except.Replace("'", "");
            //                MessageBox.Show(except);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string except = (string)ex.Message;
            //    except = except.Replace("'", "");
            //    MessageBox.Show(except);
            //}

            //End Saving UserDetails


            //try
            //{
            //    //Trained face counter
            //    ContTrain = ContTrain + 1;

            //    //Get a gray frame from capture device
            //    gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //    //Face Detector
            //    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
            //    face,
            //    1.2,
            //    10,
            //    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
            //    new Size(20, 20));

            //    //Action for each element detected
            //    foreach (MCvAvgComp f in facesDetected[0])
            //    {
            //        TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
            //        break;
            //    }

            //    //resize face detected image for force to compare the same size with the 
            //    //test image with cubic interpolation type method
            //    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //    trainingImages.Add(TrainedFace);
            //    labels.Add(txtName.Text);

            //    //Show face added in gray scale
            //    imageBox1.Image = TrainedFace;

            //    //Write the number of triained faces in a file text for further load
            //    File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

            //    //Write the labels of triained faces in a file text for further load
            //    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
            //    {
            //        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
            //        File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
            //    }

            //    MessageBox.Show(txtName.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch
            //{
            //    MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        public void EnrollFace()
        {


            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(txtName.Text);

                //Show face added in gray scale
                imageBox1.Image = TrainedFace;

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(txtName.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void FrameGrabber(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "0";
                //label4.Text = "";
                NamePersons.Add("");


                //Get the current frame form capture device
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
              face,
              1.2,
              10,
              Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
              new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        name = recognizer.Recognize(result);



                        //Draw the label for each face detected and recognized
                        //currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                        currentFrame.Draw("", ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                    }

                    NamePersons[t - 1] = name;
                    //NamePersons[t - 1] = "abc";
                    NamePersons.Add("");


                    //Set the number of faces detected on the scene
                    label3.Text = facesDetected[0].Length.ToString();

                    /*
                    //Set the region of interest on the faces
                        
                    gray.ROI = f.rect;
                    MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                       eye,
                       1.1,
                       10,
                       Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                       new Size(20, 20));
                    gray.ROI = Rectangle.Empty;

                    foreach (MCvAvgComp ey in eyesDetected[0])
                    {
                        Rectangle eyeRect = ey.rect;
                        eyeRect.Offset(f.rect.X, f.rect.Y);
                        currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                    }
                     */

                }
                t = 0;

                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = names + NamePersons[nnn] + ", ";
                }
                //Show the faces procesed and recognized
                imageBoxFrameGrabber.Image = currentFrame;
                label4.Text = names;
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();

            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("Donate.html");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabberWithLogin);
            button1.Enabled = false;
        }

        void FrameGrabberWithLogin(object sender, EventArgs e)
        {
            label3.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);
                    User usr = docHelper.LoginUser(name);
                    if (usr != null)
                    {

                        System.Diagnostics.Process.Start("http://localhost:35347/Login.aspx?name=" + name);
                        this.Close();
                    }
                    else
                    {
                        label4.Text = "Can't detect your face.";
                    }

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                    //currentFrame.Draw("", ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                }

                //NamePersons[t-1] = name;
                NamePersons[t - 1] = "abc";
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                label3.Text = facesDetected[0].Length.ToString();

                /*
                //Set the region of interest on the faces
                        
                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                }
                 */

            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            label4.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

        }

    }
}