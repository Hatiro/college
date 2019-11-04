#    Copyright(C) 2019  Vova Lantsov

#    This program is free software: you can redistribute it and/or modify
#    it under the terms of the GNU General Public License as published by
#    the Free Software Foundation, either version 3 of the License, or
#    (at your option) any later version.

#    This program is distributed in the hope that it will be useful,
#    but WITHOUT ANY WARRANTY; without even the implied warranty of
#    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
#    GNU General Public License for more details.

#    You should have received a copy of the GNU General Public License
#    along with this program. If not, see https://www.gnu.org/licenses/.

class Race:
    def __init__(self):
        pass

    @property
    def sex(self):
        return self.__sex
    
    @sex.setter
    def sex(self, value):
        self.__sex = value

    @property
    def skin_color(self):
        return self.__skin_color
    
    @skin_color.setter
    def skin_color(self, value):
        self.__skin_color = value
    
    @property
    def weight(self):
        return self.__weight
    
    @weight.setter
    def weight(self, value):
        self.__weight = value
    
    @property
    def tattoo(self):
        return self.__tattoo
    
    @tattoo.setter
    def tattoo(self, value):
        self.__tattoo = value
    
    def has_hair_color(self):
        return True
    
    @property
    def hair_color(self):
        return self.__hair_color
    
    @hair_color.setter
    def hair_color(self, value):
        if not self.has_hair_color():
            raise Exception('Hair color is not supported for this race')
        self.__hair_color = value

class Altmer(Race):
    pass

class Argonian(Race):
    def has_hair_color(self):
        return False

class Breton(Race):
    pass

class Dunmer(Race):
    pass

class Khajiit(Race):
    pass

class Nord(Race):
    pass

race_name = input('Input name of race: ')

if (race_name == 'altmer'):
    race = Altmer()
elif (race_name == 'argonian'):
    race = Argonian()
elif (race_name == 'breton'):
    race = Breton()
elif (race_name == 'dunmer'):
    race = Dunmer()
elif (race_name == 'khajiit'):
    race = Khajiit()
elif (race_name == 'nord'):
    race = Nord()
else:
    raise Exception('Specified name of race is not supported')

race.sex = input('Input sex of unit (male, female): ')
if (not race.sex == 'male' and not race.sex == 'female'):
    raise Exception(f'Not supported sex: {race.sex}')

race.skin_color = input('Input skin color of unit (green, white, black, red, blue, yellow): ')
skin_colors = set(['green', 'white', 'black', 'red', 'blue', 'yellow'])
if (not race.skin_color in skin_colors):
    raise Exception(f'Not supported skin color: {race.skin_color}')

race.weight = float(input('Input weight of unit (10.0 to 200.0): '))
if (race.weight < 10.0 or race.weight > 200.0):
    raise Exception(f"Unit's weight must be between 10.0-200.0 (inclusive), but was {race.weight}")

race.tattoo = input('Input tattoo name (or empty string if there is no tattoo): ')

if race.has_hair_color():
    race.hair_color = input("Input color of unit's hair (green, white, black, red, blue, yellow): ")
    if (not race.hair_color in skin_colors):
        raise Exception(f'Not supported color of hair: {race.hair_color}')

print(f'\nUnit of type {race_name}\nSex: {race.sex}\nSkin color: {race.skin_color}\nWeight: {race.weight}\nTattoo: {race.tattoo}')
if (race.has_hair_color()):
    print(f'Hair color: {race.hair_color}')