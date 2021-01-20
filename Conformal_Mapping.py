import igl
import numpy as np
import sys
import ast

np.set_printoptions(threshold=sys.maxsize)

def computeLCSM():

    # Storing all the data about the mesh:
    # v : array of vertex positions #v by 3
    # tc : array of texture coordinats #tc by 2
    # n : array of corner normals #n by 3
    # f : #f array of face indices into vertex positions
    # ftc : #f array of face indices into vertex texture coordinates
    # fn : #f array of face indices into vertex normals

    # parse vertex info and convert to numpy array
    v = []
    with open(sys.argv[1]) as file:
        for i in file.readlines():
            v.append(ast.literal_eval(i.strip()))        
    v = np.array(v)
    
    # parse face info and convert to numpy array
    f = []
    with open(sys.argv[2]) as file:
        for i in file.readlines():
            f.append(ast.literal_eval(i.strip()))
    f = np.array(f)

    # parse boundary vertices info and convert to numpy array
    b = ast.literal_eval((sys.argv[3]).strip())
    b = np.array(b)


    # parse boundary UV values and convert to numpy array
    bc = []
    bc.append(ast.literal_eval((sys.argv[4]).strip()))
    bc.append(ast.literal_eval((sys.argv[5]).strip()))
    bc = np.array(bc)
    

    # LSCM
    # v : #v by 3 array of mesh vertex positions
    # f : #f by 3 array of mesh faces (must be triangles)
    # b : #b boundary indices in v
    # bc : #b by 2 list of boundary values

    # returns uv #v by 2 list of 2D mesh vertex positions in UV space

    _, uv = igl.lscm(v, f, b, bc) #first is bool amd second is UV positions

    return uv

def main():

    values = computeLCSM()

    U = values[:,0]
    V = values[:,1]

    print(*U,sep=",")
    print("~")
    print(*V,sep=",")

if __name__ == "__main__":
    main()

