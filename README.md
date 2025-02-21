# Intelligent Scissors - Dijkstra-Based Lasso Cropping Tool  

## Overview  
This is an image segmentation tool implementing the **Intelligent Scissors** algorithm, which uses **Dijkstra's shortest path** to assist users in lasso-based cropping. The tool allows users to define object boundaries efficiently by clicking on an image, leveraging edge detection to guide the selection.  

## Features  
- **Image Loading:** Open and display images for editing.  
- **Gaussian Smoothing:** Apply a filter to enhance edge detection.  
- **Dijkstra-Based Pathfinding:** Automatically find the optimal path between user-defined points using edge energy calculations.  
- **Interactive Selection:** Click-based interaction to define cropping regions.  

## How It Works  
1. Load an image.  
2. Apply optional Gaussian smoothing to refine edges.  
3. Click to define control points for the selection path.  
4. The algorithm finds the best path between points using edge energy.  
5. The selected region can be extracted or modified further.  

## Technologies Used  
- **C# / Windows Forms** for UI.  
- **Bitmap Processing** for pixel-based edge calculations.  
- **Graph Algorithms** (Dijkstra) for boundary selection.  

## Usage  
1. **Open Image:** Click "Open Image" to load a file.  
2. **Gaussian Smoothing (Optional):** Adjust mask size & sigma, then click "Gauss Smooth."  
3. **Define Selection:** Click on the image to set points, and the tool will compute the best path.  

## Future Enhancements  
- Export cropped regions.  
- Multi-segment selections.  
- Enhanced edge detection with different filters.  

