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

# pylint: disable=E1101
from faker import Faker
import faker.providers.job

fake = Faker('en-US')

# ===== COURSE ABSTRACTIONS =====
class ICourse:
    def __init__(self, name, teacher):
        self.__name = name
        self.__teacher = teacher
        self.__themes = []

    def add_theme(self, theme):
        self.__themes.append(theme)
    
    def print(self):
        print(f'Course name: {self.__name}')
        self.__teacher.print()
        print(f"Count of course's themes: {len(self.__themes)}")
        for i in range(1, len(self.__themes) + 1):
            print(f'Theme {i}: {self.__themes[i - 1]}')

class ITeacher:
    def __init__(self, name):
        self.__name = name
        self.__courses = []
    
    def add_course(self, course):
        self.__courses.append(course)
    
    def print(self):
        print(f"Teacher's name: {self.__name}")
        print(f"Total count of teacher's courses: {len(self.__courses)}")

class ILocalCourse(ICourse):
    def print(self):
        print('LOCAL COURSE')
        super().print()

class IOffsiteCourse(ICourse):
    def print(self):
        print('OFFSITE COURSE')
        super().print()

# ===== COURSE FACTORY =====
class ICourseFactory:
    def __init__(self):
        self._teachers = []
        self._courses = []

    def generate_teachers(self):
        pass

    def generate_courses(self):
        pass

    @property
    def courses(self):
        return self._courses

class CourceFactory(ICourseFactory):
    def generate_teachers(self):
        for _ in range(10):
            self._teachers.append(ITeacher(fake.name()))

    def generate_courses(self):
        for teacher in self._teachers:
            localCourse = ILocalCourse(fake.job(), teacher)
            localCourse.add_theme(fake.sentence())
            self._courses.append(localCourse)
            offsiteCourse = IOffsiteCourse(fake.job(), teacher)
            offsiteCourse.add_theme(fake.sentence())
            self._courses.append(offsiteCourse)
            teacher.add_course(localCourse)
            teacher.add_course(offsiteCourse)

factory = CourceFactory()
factory.generate_teachers()
factory.generate_courses()

for course in factory.courses:
    course.print()