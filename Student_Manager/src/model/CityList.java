/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package model;

import java.util.ArrayList;

/**
 *
 * @author maiso
 */
public class CityList {
    private ArrayList<City> cityList;

    public CityList(ArrayList<City> cityList) {
        this.cityList = cityList;
    }
    
    public void removeCity(City c){
        cityList.remove(c);
    }
    public void addCity(City c){
        cityList.add(c);
    }
}
