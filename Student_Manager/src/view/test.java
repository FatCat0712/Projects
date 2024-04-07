/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package view;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author maiso
 */
public class test {
    public static void main(String[] args) throws ParseException {
//        File cityFile = new File("E:\\Java\\Project\\Student_Manager\\src\\city.txt");
//        try {
//            FileInputStream fis = new FileInputStream(cityFile);
//            InputStreamReader streamReader = new InputStreamReader(fis,"utf8");
//            BufferedReader br = new BufferedReader(streamReader);
//            String lines;
//            while((lines = br.readLine()) != null){
//                System.out.println(lines);
//            }
//        } catch (FileNotFoundException ex) {
//            Logger.getLogger(test.class.getName()).log(Level.SEVERE, null, ex);
//        } catch (IOException ex) {
//            Logger.getLogger(test.class.getName()).log(Level.SEVERE, null, ex);
//        }
          String date = "07/12/2002";
          DateFormat dateFormatter = new SimpleDateFormat("dd/MM/yyyy");
          Date d = (Date)dateFormatter.parse(date);
          System.out.println(d);
    }
    
    
}
