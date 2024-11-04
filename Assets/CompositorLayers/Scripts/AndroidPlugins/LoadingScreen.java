// Copyright (c) Meta Platforms, Inc. and affiliates.

package com.UnityCompositorLayers;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.view.Surface;

// This code is based off of https://developer.oculus.com/blog/tech-note-animated-loading-screen/

public class LoadingScreen {

  public static final String TAG = "LoadingScreen";

  private static boolean shouldUpdateLoadingScreen = false;

  public static void startUpdatingLoadingScreen(
      final Surface surface, final int width, final int height) {
    shouldUpdateLoadingScreen = true;
    new Thread(
            new Runnable() {
              @Override
              public void run() {
                Paint whitePaint = new Paint();
                whitePaint.setColor(Color.WHITE);
                whitePaint.setStrokeWidth(20);
                whitePaint.setAntiAlias(true);
                whitePaint.setStrokeCap(Paint.Cap.ROUND);
                whitePaint.setStyle(Paint.Style.STROKE);
                final int margin = 15;
                int i = 0;

                while (shouldUpdateLoadingScreen) {
                  try {
                    Canvas canvas = surface.lockCanvas(null);

                    // Draw the loading screen, eg, sprite etc.

                    canvas.drawColor(Color.TRANSPARENT, PorterDuff.Mode.CLEAR);

                    int a = (i * 2) % 360;
                    int b = (i * 3) % 720;
                    b = b > 360 ? 720 - b : b;

                    canvas.drawArc(
                        margin, margin, width - margin, height - margin, -a, -b, false, whitePaint);

                    surface.unlockCanvasAndPost(canvas);

                    Thread.sleep(16, 0);
                  } catch (Exception e) {
                    e.printStackTrace();
                    break;
                  }
                  i++;
                }

                // clear the canvas
                try {
                  Canvas canvas = surface.lockCanvas(null);
                  canvas.drawColor(Color.TRANSPARENT, PorterDuff.Mode.CLEAR);
                  surface.unlockCanvasAndPost(canvas);
                } catch (Exception e) {
                  e.printStackTrace();
                }
              }
            })
        .start();
  }

  public static void stopUpdatingLoadingScreen() {
    shouldUpdateLoadingScreen = false;
  }
}
