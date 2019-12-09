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

class Rational:
    def __init__(self, a=10.0, b=10.0):
        self.__a, self.__b = a, b

    def __gcd(self, a, b):
        while b:
            a, b = b, a % b
        return a

    @property
    def A(self):
        return self.__a
    
    @A.setter
    def A(self, value):
        self.__a = value

    @property
    def B(self):
        return self.__b
    
    @B.setter
    def B(self, value):
        self.__b = value

    def addition(self):
        return self.A + self.B

    def subtraction(self):
        return self.A - self.B

    def division(self):
        a, b = self.A, self.B

        if a % b == 0:
            return a // b
        elif not a.is_integer() or not b.is_integer():
            return (a, b)
        else:
            # Сокращаем дробь
            gcd = self.__gcd(a, b)
            return (int(a/gcd), int(b/gcd))

    def equality(self):
        return self.A == self.B

    def multiplication(self):
        return self.A * self.B

    def modeNotFound(self):
        return 'mode not found'


a = float(input('a: '))
b = float(input('b: '))
r = Rational(a, b)
print('* multiplication\n/ division\n- subtraction\n+ addition\n= equality')
mode = input('mode: ')

switcher = {
    '+': r.addition,
    '-': r.subtraction,
    '*': r.multiplication,
    '/': r.division,
    '=': r.equality
}

result = switcher.get(mode, r.modeNotFound)()
print('Result: ' + result if type(result) is str else (str(format(result[0], '.2f')) + '/' + str(format(result[1], '.2f')) if type(result) is tuple else str(format(result, '.2f'))))