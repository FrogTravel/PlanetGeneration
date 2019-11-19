# PlanetGeneration
The planet is a cube in which every vertex of a mesh is normalized to the center of the cube. To form a shape, I use pre implemented Coherent Random Noise, which gives beautiful wavy shape for my planets. To get better results, I add several layers with such randomly generated surfaces together.
To create the simulation of sea level, I set the minimum point, and if noise gives value below that point, I set this vertex to minPoint. Here is a nice picture of a simple noise generator with sea level.
To make the planet more complex and diverse, I also implemented different types of noise. It can be written as follows:
(1 − |Noise(x)|)2
Such a formula produces strong picks that are like mountains on our planet. Here is an illustration for this filter

To make planets even more exciting and more nature- like, I combined several noise layers. For the ”continent” generation - a simple noise filter works fine; then I add mountains as a second layer. The first layer is used as a mask for mountains. That way, they don’t appear on ”beach” or in the middle of an ocean.

The planet’s look is tuned with a lot of parameters. The strength is responsible for the height of noise. The larger the strength - the higher the mountain will be gen- erated. Roughness is capable of how wavy that level of noise will be. The bigger that value, the more bubbly the planet becomes (or sharp in case of more advanced noise). Min value is the sea level of the planet. The ”center” allows moving the layer around the planet. All those parameters are available per each layer. The com-
bination of several layers gives impeccable results. To color the planet, I implemented a shader, that color the surface based on the height of the point. The color now is set manually.

### Evaluation
Because this method uses several layers of different noise, where each layer consist of several inner noise layers the results are very different planets

### Future work
I propose to implement the color generation for the planet. Several rules can be applied, for instance, the peak of mountains probably will be white because of snow or black if there is no atmosphere on the planet and so on. Also, significant improvement is to imple- ment an atmosphere like gloving, that is used in the Spore game, to give the planet more alive-look.

### References
[1] https://www.youtube.com/user/Cercopithecan   
