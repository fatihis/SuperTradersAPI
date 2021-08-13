using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SuperTradersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTradersAPI.Utils
{
    public class CRUDOperations
    {
        #region global
        public string ConnectionString { get; set; }

        public CRUDOperations(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        #endregion

        #region Users CRUD
        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();//creating list to fill with retrieved data

            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from users", conn); //construct query
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                            list.Add(new User()
                            {

                                userId = Convert.ToInt32(reader["userId"]),
                                walletId = Convert.ToInt32(reader["walletId"])
                            });
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }

            return list;
        }
        public User GetUser(int id)
        {
            User getUserItem = new User();//creating User object to equal retrieved data

            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from users where userId = '" + id + "'", conn);//construct query
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                            getUserItem = new User()
                            {

                                userId = Convert.ToInt32(reader["userId"]),
                                walletId = Convert.ToInt32(reader["walletId"]),
                            };
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }
            }
            return getUserItem;
        }
        public User UpdateUser(User updatedUserData)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string updateUserCmdString = "update users set userId=@userId, walletId=@walletId where userId= '" + updatedUserData.userId + "'";


                MySqlCommand cmd = new MySqlCommand(updateUserCmdString, conn);//construct query
                try
                {

                    //fill predefined parameters
                    cmd.Parameters.AddWithValue("@userId", updatedUserData.userId);
                    cmd.Parameters.AddWithValue("@walletId", updatedUserData.walletId);
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                        }
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }
            return updatedUserData;
        }
        public int deleteUser(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string deleteUserCmdString = "DELETE FROM users WHERE userId=" + id;
                MySqlCommand cmd = new MySqlCommand(deleteUserCmdString, conn);//construct query
                try
                {

                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                        }
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }
            return id;

        }
        public User AddUser(User UserToAdd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string insertUserCmdString = "insert into users (userId,walletId) values ('" + UserToAdd.userId + "','" + UserToAdd.walletId + "')";
                MySqlCommand cmd = new MySqlCommand(insertUserCmdString, conn);//construct query
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                        }
                    }
                    AddWallet(new Wallet
                    {
                        walletId = UserToAdd.walletId,
                        walletSharesId= UserToAdd.walletId,
                    });
                    return UserToAdd;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                    return UserToAdd;
                }

            }
        }
        #endregion

        #region Shares CRUD
        public List<Share> GetAllShares()
        {
            List<Share> list = new List<Share>();//creating list to fill with retrieved data

            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from shares", conn); //construct query
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                            list.Add(new Share()
                            {
                                shareId = Convert.ToInt32(reader["shareId"]),
                                sharePrice = Convert.ToDouble(reader["sharesprice"]),
                                shareAmount = Convert.ToDouble(reader["shareAmount"]),
                                shareSymbol = Convert.ToString(reader["shareSymbol"]),
                                shareTotal = Convert.ToDouble(reader["shareTotal"]),
                            });
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }

            return list;
        }
        public Share GetShare(string symbol)
        {
            Share getShareItem = new Share();//creating User object to equal retrieved data

            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from shares where shareSymbol = '" + symbol + "'", conn);//construct query
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                            getShareItem = new Share()
                            {
                                shareId = Convert.ToInt32(reader["shareId"]),
                                sharePrice = Convert.ToDouble(reader["sharesprice"]),
                                shareAmount = Convert.ToDouble(reader["shareAmount"]),
                                shareSymbol = Convert.ToString(reader["shareSymbol"]),
                                shareTotal = Convert.ToDouble(reader["shareTotal"]),
                            };
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }
            }
            return getShareItem;
        }
        public Share UpdateShare(Share updatedShareData)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string updateShareCmdString = "update shares set shareId=@shareId, sharesprice=@sharesprice,shareAmount=@shareAmount,shareSymbol=@shareSymbol,shareTotal=@shareTotal where shareId = '" + updatedShareData.shareId + "'";
                //string updateUserCmdString = "update shares set shareId=@shareId, sharesprice=@sharesprice, shareAmount=@shareAmount, shareSymbol=@shareSymbol, shareTotal=@shareTotal  where userId= '" + updatedUserData.userId + "'";

                MySqlCommand cmd = new MySqlCommand(updateShareCmdString, conn);//construct query
                try
                {

                    //fill predefined parameters
                    cmd.Parameters.AddWithValue("@shareId", updatedShareData.shareId);
                    cmd.Parameters.AddWithValue("@sharesprice", updatedShareData.sharePrice);
                    cmd.Parameters.AddWithValue("@shareAmount", updatedShareData.shareAmount);
                    cmd.Parameters.AddWithValue("@shareSymbol", updatedShareData.shareSymbol);
                    cmd.Parameters.AddWithValue("@shareTotal", updatedShareData.shareTotal);
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                        }
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }
            return updatedShareData;
        }
        public int deleteShare(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string deleteShareCmdString = "DELETE FROM users WHERE shareId=" + id;
                MySqlCommand cmd = new MySqlCommand(deleteShareCmdString, conn);//construct query
                try
                {

                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                        }
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }
            return id;

        }
        public Share AddShare(Share ShareToAdd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string insertShareCmdString = "insert into shares (shareId,shareAmount,shareTotal,sharesprice,shareSymbol) values ('" + ShareToAdd.shareId + "','" + ShareToAdd.shareAmount  + "','" + ShareToAdd.shareTotal + "','" + ShareToAdd.sharePrice +"','" + ShareToAdd.shareSymbol + "')";
                MySqlCommand cmd = new MySqlCommand(insertShareCmdString, conn);//construct query
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                        }
                    }
                    return ShareToAdd;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                    return ShareToAdd;
                }

            }
        }

        #endregion
        #region wallet CRUD
        public Wallet GetWallet(int walletid)
        {
            Wallet getWalletItem = new Wallet();//creating User object to equal retrieved data

            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from wallets where walletId = '" + walletid + "'", conn);//construct query
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                            getWalletItem = new Wallet()
                            {
                                walletId = Convert.ToInt32(reader["walletId"]),
                                walletSharesId = Convert.ToInt32(reader["walletSharesId"]),
                            };
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }
            }
            return getWalletItem;
        }
        public WalletShares GetWalletShareBySymbol(int walletId,string symbol)
        {
            WalletShares getWalletSharesItem = new WalletShares();//creating User object to equal retrieved data
            Wallet wallet = GetWallet(walletId);
            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from walletshares where walletSharesId = '" + wallet.walletSharesId + "' AND shareSymbol = '"+ symbol + "' ", conn);//construct query
                conn.Open();

                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                            getWalletSharesItem = new WalletShares()
                            {
                                walletSharesId = Convert.ToInt32(reader["walletSharesId"]),
                                shareSymbol = Convert.ToString(reader["shareSymbol"]),
                                shareAmount = Convert.ToDouble(reader["shareAmount"]),

                            };
                        }
                    }

            }
            return getWalletSharesItem;
        }
        public Wallet AddWallet(Wallet wallet)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string insertWalletCmdString = "insert into wallets (walletId,walletSharesId) values ('" + wallet.walletId + "','" + wallet.walletSharesId + "')";
                MySqlCommand cmd = new MySqlCommand(insertWalletCmdString, conn);//construct query
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                        }
                    }
                    return wallet;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                    return wallet;
                }

            }
        }
        //public WalletShares CreateWallet(WalletShares walletShares)
        //{
        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        string insertUserCmdString = "insert into walletshares (userId,walletId) values ('" + walletShares.walletSharesId + "','" + walletShares. + "')";
        //        MySqlCommand cmd = new MySqlCommand(insertUserCmdString, conn);//construct query
        //        try
        //        {
        //            using (var reader = cmd.ExecuteReader())//execute query
        //            {
        //                while (reader.Read())
        //                {

        //                }
        //            }
        //            return UserToAdd;
        //        }
        //        catch (ArgumentException e)
        //        {
        //            Console.WriteLine("error: " + e);
        //            return UserToAdd;
        //        }

        //    }
        //}
        public WalletShares AddWalletShares(WalletShares ShareToAdd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string insertShareCmdString = "insert into walletshares (walletSharesId,shareAmount,shareSymbol) values ('" + ShareToAdd.walletSharesId + "','" + ShareToAdd.shareAmount + "','" + ShareToAdd.shareSymbol + "')";
                MySqlCommand cmd = new MySqlCommand(insertShareCmdString, conn);//construct query
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                        }
                    }
                    return ShareToAdd;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                    return ShareToAdd;
                }

            }
        }
        public WalletShares UpdateWalletShares(WalletShares updatedShareData)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string updateWalletSharesCmdString = "update walletShares set walletSharesId=@walletSharesId, shareSymbol=@shareSymbol,shareAmount=@shareAmount where walletSharesId= '" + updatedShareData.walletSharesId + "' AND shareSymbol = '" + updatedShareData.shareSymbol + "' ";


                MySqlCommand cmd = new MySqlCommand(updateWalletSharesCmdString, conn);//construct query
                try
                {

                    //fill predefined parameters
                    cmd.Parameters.AddWithValue("@walletSharesId", updatedShareData.walletSharesId);
                    cmd.Parameters.AddWithValue("@shareSymbol", updatedShareData.shareSymbol);
                    cmd.Parameters.AddWithValue("@shareAmount", updatedShareData.shareAmount);

                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {
                        }
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }
            return updatedShareData;
        }


        #endregion

        #region transactions
        public int BuyShare(int userId, string shareSymbol, double amount)
        {
            User buyingUser = GetUser(userId);
            WalletShares walletShares = GetWalletShareBySymbol(buyingUser.walletId,shareSymbol);
            Share shareToUpdate = GetShare(shareSymbol);

            if (shareToUpdate.shareAmount > amount)
            {
                shareToUpdate.shareAmount = shareToUpdate.shareAmount - amount;

                    if(walletShares.shareAmount > 0)
                    {
                        walletShares.shareAmount = walletShares.shareAmount + amount;
                        UpdateWalletShares(walletShares);
                    }
                    else if(walletShares.shareAmount == 0)
                    {
                        AddWalletShares(new WalletShares {
                        walletSharesId= buyingUser.walletId,
                        shareSymbol = shareSymbol,
                        shareAmount = amount
                        });
                    }
                    UpdateShare(shareToUpdate);
                Log buyLog = new Log
                {
                    logId = 0,
                    logTxt ="User ID:"+ buyingUser.userId + ", bought " + amount + " " + shareSymbol + " shares for " + (amount*shareToUpdate.sharePrice) + " $ " ,
                    userId = userId,
                };
                createLog(buyLog);
                    return 200;
                }
            else
            {
                return 400;
            }
        }
        public int SellShare(int userId, string shareSymbol, double amount)
        {
            User sellingUser = GetUser(userId);
            WalletShares walletShares = GetWalletShareBySymbol(sellingUser.walletId,shareSymbol);
            Share shareToUpdate = GetShare(shareSymbol);

            if (walletShares.shareAmount > amount)
            {
                shareToUpdate.shareAmount = shareToUpdate.shareAmount + amount;

                    if(walletShares.shareAmount > 0)
                    {
                        walletShares.shareAmount = walletShares.shareAmount - amount;
                    }
                    else if(walletShares.shareAmount == 0)
                    {
                    return 400;
                    }
                    UpdateWalletShares(walletShares);
                    UpdateShare(shareToUpdate);
                    Log buyLog = new Log
                    {
                        logId = 0,
                        logTxt = "User ID:" + sellingUser.userId + ", sold "+ amount +" "+ shareSymbol + " shares for " + (amount * shareToUpdate.sharePrice) + " $ ",
                        userId = userId,
                    };
                createLog(buyLog);
                return 200;
                }
            else
            {
                return 400;
            }
        }
        #endregion
        #region logs
        public void createLog(Log newLog)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string insertLogCmdString = "insert into transactionlogs (logId,logTxt,userId) values ('" + newLog.logId + "','" + newLog.logTxt + "','" + newLog.userId + "')";
                MySqlCommand cmd = new MySqlCommand(insertLogCmdString, conn);//construct query
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }

            }
        }
        public List<Log> GetAllLogs()
        {
            List<Log> list = new List<Log>();
            //creating list to fill with retrieved data

            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from transactionlogs", conn); //construct query
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                            list.Add(new Log()
                            {
                                logId = Convert.ToInt32(reader["logId"]),
                                logTxt = Convert.ToString(reader["logTxt"]),
                                userId = Convert.ToInt32(reader["userId"])
                            });
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }


            }

            return list;
        }
        public List<Log> GetLogByUserId(int id)
        {
            List<Log> list = new List<Log>();//creating User object to equal retrieved data

            using (MySqlConnection conn = GetConnection())
            {


                MySqlCommand cmd = new MySqlCommand("select * from transactionlogs where userId = '" + id + "'", conn);//construct query
                conn.Open();
                try
                {
                    using (var reader = cmd.ExecuteReader())//execute query
                    {
                        while (reader.Read())
                        {

                            list.Add(new Log()
                            {
                                logId = Convert.ToInt32(reader["logId"]),
                                logTxt = Convert.ToString(reader["logTxt"]),
                                userId = Convert.ToInt32(reader["userId"])
                            });
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("error: " + e);
                }
            }
            return list;
        }
        #endregion
    }
}
