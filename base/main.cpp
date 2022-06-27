#include "solutions.h"
#include <cmath>
#include <iostream>

int main()
{
    std::cout << "Enter the values of the quadratic equation arranged as 'ax² + bx + c = 0': ";
    
    int a{}, b{}, c{};
    std::cin >> a >> b >> c;
    
    double delta { pow(b, 2) - 4 * a * (c) };
    //std::cout << "Delta = " << delta << '\n';
    
    double x { solutionPlus(a, b, delta) };
    double y { solutionMinus(a, b, delta) };
    //std::cout << "x' = " << x << " / x'' = " << y << '\n';
    std::cout << "S = {" << x << ", " << y << "}";
}