﻿using BlockchainApp.Code;
using Newtonsoft.Json;

Console.WriteLine("Blockchain starting...");

List<Transaction> transactions = new List<Transaction>
        {
            new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = Guid.NewGuid(),
                //AccountId = "0xDb9E20D9A5fa926c0c14a07f84204767B83a4E74",
                TransactionDate = DateTime.Now,
                TransactionAmount = 330500m,
                Memo = "101 N Main St Greenwood, IN"
            },
            new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = Guid.NewGuid(),
                //AccountId = "0xDb9E20D9A5fa926c0c14a07f84204767B83a4E74",
                TransactionDate = DateTime.Now,
                TransactionAmount = 474900m,
                Memo = "421 Pearl St Columbus, IN"
            },
            new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = Guid.NewGuid(),
                //AccountId = "0xDb9E20D9A5fa926c0c14a07f84204767B83a4E74",
                TransactionDate = DateTime.Now,
                TransactionAmount = 515000m,
                Memo = "416 Banta St Franklin, IN"
            }
        };

Blockchain blockchain = new Blockchain(2);

foreach (Transaction transaction in transactions)
{
    string data = JsonConvert.SerializeObject(transaction);

    Console.WriteLine($"Adding block: {data}");

    Block block = new Block(blockchain.GetLatestBlock().Index + 1, DateTime.Now, data, blockchain.GetLatestBlock().Hash);
    blockchain.AddBlock(block);
}
Console.WriteLine("========================Is Valid Chain==============================");
Console.WriteLine($"Checking if blockchain is valid: {blockchain.IsChainValid()}");
Console.WriteLine("++++++++++++++++++++++++Is Valid Chain++++++++++++++++++++++++++++++");
Console.WriteLine("========================Data==============================");
Console.WriteLine($"Blockchain: {JsonConvert.SerializeObject(blockchain, Formatting.Indented)}");
Console.WriteLine("++++++++++++++++++++++++End Data++++++++++++++++++++++++++");