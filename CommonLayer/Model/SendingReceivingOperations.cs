//using Experimental.System.Messaging;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CommonLayer.Model
//{
//    public class SendingReceivingOperations
//    {
//        MessageQueue sendingReceivingOperations = new MessageQueue();
//        public void SenderProcess(string token)
//        {
            
//            //Setting the QueuPath where we want to store the messages.
//            sendingReceivingOperations.Path = @".\private$\Token";

//            //2.Now to check Queue existence:

//            if(!MessageQueue.Exists(sendingReceivingOperations.Path))
//            {
//                // Creates the new queue named "Bills"

//                MessageQueue.Create(sendingReceivingOperations.Path);

//            }
            
//            sendingReceivingOperations.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

//            sendingReceivingOperations.ReceiveCompleted += SendingReceivingOperations_ReceiveCompleted;
//            sendingReceivingOperations.Send("Desired Messages");

//            sendingReceivingOperations.BeginReceive();

//            sendingReceivingOperations.Close();


//        }

//        private void SendingReceivingOperations_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
//        {
//            var msg = sendingReceivingOperations.EndReceive(e.AsyncResult);

//            string token = msg.Body.ToString();
//            //mail send through SMTP

//            //msmq receiver
//            sendingReceivingOperations.BeginReceive();
            
            





//        }

//        public void SenderProcess(object token)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

