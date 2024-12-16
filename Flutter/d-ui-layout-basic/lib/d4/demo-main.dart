// ignore_for_file: use_key_in_widget_constructors, file_names, prefer_const_constructors

import 'package:flutter/material.dart';

// Padding Widget of the Week
// https://www.youtube.com/watch?v=oD5RtLhhubg&vl=en

// Padding widget by RetroStudio
// https://www.youtube.com/watch?v=d9wQuxPZ494&list=PLybADvIp2cxiVOEHi9ooCHP2tAAihHQPX&index=7

// Note: that there is NO Margin Widget.

class Demo extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text(
          'D4 - Padding Widget',
        ),
      ),
      body: Padding(
          // From the perspective of the Padding
          // widgets child, in this case a Container,
          // the padding parm really acts as a margin.
          //padding: const EdgeInsets.fromLTRB(10, 20, 30, 40),
          //padding: const EdgeInsets.symmetric(vertical: 20, horizontal: 40),
          padding: const EdgeInsets.all(20.0),
          child: Container(
            //margin: const EdgeInsets.fromLTRB(50.0, 40.0, 20.0, 10.0),
            //padding: EdgeInsets.fromLTRB(10, 20, 30, 40),
            height: 400.0,
            width: 340.0,
            decoration: const BoxDecoration(
              shape: BoxShape.rectangle,
              color: Colors.amber,
            ),
            child: Image.asset('./lib/assets/images/bottle.jpg'),
          ),
        ),
    );
  }
}
