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

import uuid

class Project:
    def __init__(self, name, price):
        self.__name = name
        self.__price = price

    @property
    def name(self):
        return self.__name

    @property
    def price(self):
        return self.__price

    @staticmethod
    def uid():
        return uuid.uuid4()

    def markup(self):
        pass

    def discount(self):
        pass

    def save_project_info(self):
        with open('file.txt', 'w+') as file:
            file.write(f'Uid: {self.uid()} Project name: {self.name} Price: {self.price}')

    @staticmethod
    def print_all_lines_from_file():
        with open('file.txt', 'r') as file:
            for line in file:
                print(line)


class StandardProject(Project):
    pass

class TenDaysProject(Project):
    def markup(self):
        return self.price + self.price * 0.6

class InvestorProject(Project):
    def markup(self):
        return self.price + self.price * 0.2

    def discount(self):
        return self.price * 0.2


pr_name = input('Input project name: ')
pr_price = float(input('Input project price: '))
pr_type = input('Input project type (standard, ten_days, investor): ')

project = Project(pr_name, pr_price)
if pr_type == 'standard':
    project = StandardProject(pr_name, pr_price)
elif pr_type == 'ten_days':
    project = TenDaysProject(pr_name, pr_price)
elif pr_type == 'investor':
    project = InvestorProject(pr_name, pr_price)
else:
    raise Exception(f'Not supported project type {pr_type}')

project.discount()
project.markup()

project.save_project_info()
print('Successfully written to file')

Project.print_all_lines_from_file()