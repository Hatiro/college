class Employee:
    def __init__(self, salary):
        self._salary = salary

    def average_salary(self):
        pass

class StaticPaidEmployee(Employee):
    def average_salary(self):
        return self._salary

class HourlyPaidEmployee(Employee):
    def average_salary(self):
        return self._salary * 20.8 * 8

employees = []

employees.append(StaticPaidEmployee(1600))
employees.append(HourlyPaidEmployee(14))
employees.append(HourlyPaidEmployee(9))
employees.append(StaticPaidEmployee(500))

def sort_employee(elem):
    return elem.average_salary()

for employee in sorted(employees, key=sort_employee):
    print(employee.average_salary())