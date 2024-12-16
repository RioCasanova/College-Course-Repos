// ignore_for_file: avoid_print, use_build_context_synchronously

import 'package:firebase_auth/firebase_auth.dart';
import 'package:robbinlaw/widgets/mysnackbar.dart';
import 'package:robbinlaw/d9/services/database.dart';

class Authorization {
  User? currentUser = FirebaseAuth.instance.currentUser;

  void listen() {
    FirebaseAuth.instance.authStateChanges().listen((User? user) {
      if (user == null) {
        print('Auth listen; No User');
      } else {
        print('Auth listen: email= ${user.email} name= ${user.displayName}');
      }
    });
  }

  Future<void> createUser(String name, String email, String password) async {
    try {
      print('Auth createUser: TRY');
      UserCredential credential =
          await FirebaseAuth.instance.createUserWithEmailAndPassword(
              email: email.trim(), password: password);
      await credential.user?.updateDisplayName(name);
      User? user = FirebaseAuth.instance.currentUser;
      await Database().createNewUser(user?.uid, user?.displayName, user?.email);
      print('signed up with ${user?.displayName}');
      MySnackBar(text: '${user?.displayName} signUp: SUCCESS').show();
    } catch (e) {
      print('Auth createUser: CATCH $e');
      MySnackBar(text: 'signUp: FAILED').show();
    }
  }

  Future<void> logIn(String email, String password) async {
    try {
      print('Auth logIn: TRY');
      await FirebaseAuth.instance
          .signInWithEmailAndPassword(email: email.trim(), password: password);
      print('logIn with ${email.trim()}');
      MySnackBar(text: '${email.trim()} logIn: SUCCESS').show();
    } catch (e) {
      print('Auth logIn: CATCH $e');
      MySnackBar(text: 'logIn: FAILED').show();
    }
  }

  Future<void> logOut() async {
    try {
      print('Auth logOut: TRY');
      await FirebaseAuth.instance.signOut();
      print('logged out');
      MySnackBar(text: 'logOut: SUCCESS').show();
    } catch (e) {
      print('Auth logOut: CATCH $e');
      MySnackBar(text: 'logOut: FAILED').show();
    }
  }
}
