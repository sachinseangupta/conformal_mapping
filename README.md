# conformal_mapping
Apply least squares conformal mapping parameterization to an input Grasshopper mesh.

This tool parameterizes a 3D open triangulated mesh in Grasshopper to 2D space with the goal of maintaining the angular relationships of the mesh faces while allowing the area of the faces to change. It make use of the libigl computational geometry library which contains the least squares conformal mapping algorithm. More info can be found here: https://libigl.github.io/tutorial/#least-squares-conformal-maps

The Grasshopper file parses the vertex and face information of the mesh and sends the data to an external Python program which applies the conformal mapping algorithm and sends the data back to Grasshopper. This data exchange is accomplished through a C# script within Grasshopper.

![CM_combined](https://user-images.githubusercontent.com/63329231/105245245-983af500-5b3f-11eb-8313-e2e89d0cf21d.png)

*Figure: (Left) 2D mapped output of mesh face area change with reciprocal strut units overlaid. (Right) 3D remapped output of mesh face area change with distorted reciprocal strut units.*


Conformal mapping help solve the age-old problem of flattening a 3D curved object (such as a globe) with minimal angular distortion (a map where the relationships between latitude and longitudinal lines are kept constant). It is useful for architectural tessellation challenges where angular relationships between elements in crucial. For example, this tool can be used for reciprocal frame or reciprocal tensegrity structures where the reciprocal geometric relationships are key to structural performance.

Please contact me for the full .zip folder which will contain all the necessary libaries and a Python .exe file for the tool to be used.
