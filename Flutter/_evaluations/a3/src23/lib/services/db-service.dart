// ignore_for_file: todo, avoid_print, library_prefixes, avoid_function_literals_in_foreach_calls, file_names, unused_import

import 'package:path/path.dart' as pathPackage;
import 'package:sqflite/sqflite.dart' as sqflitePackage;

class SQFliteDbService {
  late sqflitePackage.Database? db;
  late String path;

  Future<void> getOrCreateDatabaseHandle() async {
    try {
      //TODO: Put your code here to complete this method.
      var databasesPath = await sqflitePackage.getDatabasesPath();
      path = pathPackage.join(databasesPath, 'app_database.db');
      db = await sqflitePackage.openDatabase(
        path,
        onCreate: (sqflitePackage.Database db, int version) async {
          await db.execute(
              'CREATE TABLE Stocks(name TEXT PRIMARY KEY, price INTEGER, symbol TEXT)');
        },
        version: 1,
      );
      print('db = $db');
    } catch (e) {
      print('SQFliteDbService getOrCreateDatabaseHandle CATCH: $e');
    }
  }

  Future<void> printAllStocksInDbToConsole() async {
    try {
      //TODO: Put your code here to complete this method.
      List<Map<String, dynamic>> stocks = await getAllStocksFromDb();
      if (stocks.isEmpty) {
        print('No records in the db');
      } else {
        stocks.forEach((stock) {
          print(
              '{name: ${stock['name']}, price: ${stock['price']}, symbol: ${stock['symbol']}}');
        });
      }
    } catch (e) {
      print('SQFliteDbService printAllStocksInDbToConsole CATCH: $e');
    }
  }

  Future<List<Map<String, dynamic>>> getAllStocksFromDb() async {
    try {
      //TODO: Put your code here to complete this method.
      // Replace this return with valid data.
      final List<Map<String, dynamic>> stocks = await db!.query('Stocks');
      return stocks;
    } catch (e) {
      print('SQFliteDbService getAllStocksFromDb CATCH: $e');
      return <Map<String, dynamic>>[];
    }
  }

  Future<void> deleteDb() async {
    try {
      //TODO: Put your code here to implement this method.
      await sqflitePackage.deleteDatabase(path);
      print('Db deleted');
      db = null;
    } catch (e) {
      print('SQFliteDbService deleteDb CATCH: $e');
    }
  }

  Future<void> insertStock(Map<String, dynamic> stock) async {
    try {
      //TODO:
      //Put code here to insert a stock into the database.
      //Insert the Stock into the correct table.
      //Also specify the conflictAlgorithm.
      //In this case, if the same stock is inserted
      //multiple times, it replaces the previous data.
      await db!.insert(
        'Stocks',
        stock,
        conflictAlgorithm: sqflitePackage.ConflictAlgorithm.replace,
      );
    } catch (e) {
      print('SQFliteDbService insertStock CATCH: $e');
    }
  }

  Future<void> updateStock(Map<String, dynamic> stock) async {
    try {
      //TODO:
      //Put code here to update stock info.
      await db!.update(
        'Stocks',
        stock,
        where: 'name = ?',
        whereArgs: [stock['name']],
      );
    } catch (e) {
      print('SQFliteDbService updateStock CATCH: $e');
    }
  }

  Future<void> deleteStock(Map<String, dynamic> stock) async {
    try {
      //TODO:
      //Put code here to delete a stock from the database.
      await db!.delete(
        'Stocks',
        where: 'name = ?',
        whereArgs: [stock['name']],
      );
    } catch (e) {
      print('SQFliteDbService deleteStock CATCH: $e');
    }
  }
}
