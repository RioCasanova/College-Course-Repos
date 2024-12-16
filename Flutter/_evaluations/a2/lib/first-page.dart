// ignore_for_file: avoid_print, use_key_in_widget_constructors, file_names, todo, prefer_const_constructors, prefer_const_literals_to_create_immutables, unused_import

import 'package:flutter/material.dart';
import './widgets/mysnackbar.dart';

// Do not change the structure of this files code.
// Just add code at the TODO's.

final formKey = GlobalKey<FormState>();

// We must make the variable firstName nullable.
String? firstName;
final TextEditingController textEditingController = TextEditingController();

class MyFirstPage extends StatefulWidget {
  @override
  MyFirstPageState createState() => MyFirstPageState();
}

class MyFirstPageState extends State<MyFirstPage> {
  bool enabled = false;
  int timesClicked = 0;
  String msg1 = '';
  String msg2 = '';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('App2'),
      ),
      body: Column(
        children: <Widget>[
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              //TODO: Build the label and switch here
              //as children of the row.
              const Text('Enable Buttons'),
              Switch(
                  value: enabled,
                  onChanged: (bool onChangedValue) {
                    print('onChangedValue is $onChangedValue');
                    // enabled is now DIRTY after next statement.
                    enabled = onChangedValue;
                    setState(() {
                      if (enabled) {
                        timesClicked = 0;
                        msg1 = 'Enabled';
                        print('enabled is true');
                      } else {
                        msg1 = 'Disabled';

                        print('enabled is false');
                      }
                    });
                  }),
            ],
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              //TODO: Build the two buttons here as children of the row.
              // For each button use a "Visibility Widget" and its child
              // will be an "ElevatedButton"
              const SizedBox(
                height: 20,
              ),
              Visibility(
                visible: enabled,
                child: ElevatedButton(
                  onPressed: () {
                    setState(() {
                      timesClicked++;
                      msg1 = 'Clicked $timesClicked';
                      print('clicked $timesClicked');
                    });
                  },
                  child: Text(msg1),
                ),
              ),
              Visibility(
                visible: enabled,
                child: ElevatedButton(
                  onPressed: () {
                    setState(() {
                      // the reset stuff
                      msg1 = 'Enabled';
                      timesClicked = 0;
                      textEditingController.clear();
                      firstName = '';
                      msg2 = 'firstName field has been reset';
                      print(msg2);
                    });
                  },
                  child: Text('Reset'),
                ),
              ),
            ],
          ),
          Form(
            key: formKey,
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                children: [
                  //TODO: Build the text form field here as the first
                  // child of the column.
                  // Include as the second child of the column
                  // a submit button that will show a
                  // snackbar with the "firstName" if validation
                  // is satisfied.
                  const SizedBox(
                    height: 20,
                  ),
                  TextFormField(
                    controller: textEditingController,
                    onChanged: (value) {
                      print(value);
                    },
                    onFieldSubmitted: (text) {
                      print('Name Entered: $text');
                      if (formKey.currentState!.validate()) {
                        print('valid name');
                      }
                    },
                    validator: (input) {
                      return input!.isEmpty ? 'min 1 char please' : null;
                    },
                    onSaved: (input) {
                      print('onSaved password = $input');
                      firstName = input;
                    },
                    obscureText: false,
                    maxLength: 20,
                    decoration: const InputDecoration(
                      icon: Icon(Icons.emoji_emotions),
                      labelText: 'first name',
                      helperText: 'min 1, max 20',
                      suffixIcon: Icon(
                        Icons.check_circle,
                      ),
                    ),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: <Widget>[
                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: ElevatedButton(
                          onPressed: () {
                            if (formKey.currentState!.validate()) {
                              formKey.currentState!.save();
                              // This is where the snackbar will go
                              MySnackBar(
                                      text: 'Hey, Nice to mee you $firstName')
                                  .show();
                              textEditingController.clear();
                              setState(() {});
                            }
                          },
                          child: const Text('Submit'),
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
