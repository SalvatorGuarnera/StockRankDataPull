# StockRankDataPull

This code powers StockRank.  It uses a Selenium Webdriver to automate WebCrawling across 500 stocks on the S&P 500.

It collects a variety of data, POSTs data and stores in a Google Realtime Database.

The app is written in C#.  A containerized instance of the app is created through Docker.  

Future intention is to deploy this containerized instance to a Cloud Run environment to run every night at midnight.
