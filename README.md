# Run



## 开发过程记录

#### 1. 创建冰块、小球以及相机跟随

- 冰块的缩放动画用 **DOTween** 的 `transform.DOScale()` ，动画结束回调 `MeltOver()` 和 `FreezeOver()` 函数，冰块尺寸过小时销毁该冰块。
- 小球利用 `Input.GetAxis()` 获取键盘方向键移动。
- 相机利用 `Vector3.SmoothDamp()` 缓缓跟随 **Player** 。

#### 2. 跳板和红色的炸弹

- **Player** 碰到跳板的 **Collider** 碰撞器，跳板给 **Player** 一个斜向上的力。
- 跳板同时变化颜色，利用用 **DOTween** 的 `material.DOColor()` 。
- 红色炸弹在触碰 **Player** 时的一个接触点 `collision.contacts[0].point` 处施加爆炸力 ` collision.rigidbody.AddExplosionForce()` 。

#### 3. 添加RepeatMove脚本

- 该脚本可以在**x**轴和**y**轴方向上重复来回运动。
- 自定义枚举类型 **VHType** 用来标记该脚本挂载的游戏物体重复运动的方向。
- 只暴露了运动路径两头的坐标，而物体在场景中的位置则为起始位置，游戏开始时全部先向终点移动，在场景中**错开排列**则可使得其与同类物体保持固定的差距。

- 为了在 **Inspector** 面板可以方便调整，使得**上下**和**左右**两个不同方向上运动的物体在 **Inspector** 面板上只看到所选方向的两个终点坐标，创建了 **RepeatMoveEditor** 脚本继承 **Editor** 类，根据不同方向在 **Inspector** 面板上暴露不同组坐标。
- 该脚本用在了大部分会重复的物体上。

#### 4. 相机视角变换

- 关卡最后的部分由于视角看不清板块上下移动的位置，不利于判断能否跳到下一板块，添加了第二个视角 `UpView` ，该视角下相机与 **Player** 的相对位置及相机角度事先调好。
- 视角转换的过渡动画由 `DOTween.To()` 调整相机与 **Player** 间相对位置 `offSet` 完成。

#### 5. 创建Trigger脚本

- 由于在多个地方需要触发另外一个游戏物体的某个函数操作，为了减少在不同脚本中都写一遍类似的代码，因此专门创建了一个 **Trigger** 脚本。
- 挂载此脚本的物体的碰撞器如果碰撞到标签与所指定的 **Obeject Tag** 标签符合的物体时，向指定的物体 **Call Object** 发送消息调用其名为 **Call Func** 的函数。

#### 6. 创建激光Laser

- 激光的运动效果为旋转，与 **RepeatMove** 类似，不过可以分别在**XYZ**三个轴上旋转。

#### 7. NavMesh动态生成和寻路

- 添加 **NavMeshBuilder** 挂载 **LocalNavMeshBuilder** 组件，调整烘焙范围。
- 在冰块和石头上添加 **NavMeshSourceTag** 标记为烘焙对象。
- 小冰球利用 `NavMeshAgent.SetDestination()` 方法跟随 **Player** ，并间隔一段时间更新目标位置。

#### 8. 安卓版本与摇杆控制

- 安装 **Android Module** 、 **JDK** 、**SDK** 。
- 摇杆的显示为 **Canvas** 内的两个 **Button** 或 **Image** ，背景**Image**作为父物体挂载 **JoyStick** 脚本。
- **JoyStick** 类实现三个接口 `IDragHandler, IPointerDownHandler, IPointerUpHandler`  

- `OnDrag(PointerEventData eventData)` 为屏幕上手指**拖拽**或鼠标指针**拖拽**时调用，若 **Pointer** 位置在背景**Image**范围内则计算该 **Pointer** 位置相对圆心的**运动方向向量**并规范化。
- `OnPointerDown(PointerEventData eventData)` 为指针**按下**时调用，仅需调用 `OnDrag()` 即可。
- `OnPointerUp(PointerEventData eventData)` 为指针**抬起**时调用，将前景**Image**归位并将**运动方向向量**归零。
- **运动方向向量**的值由函数 `Horizontal()` 和 `Vertical()` 暴露，若没有手指拖拽或鼠标指针拖拽则返回 `Input.GetAxis()` 对应的值。

#### 9. 存档

- 由挂载 **Trigger** 碰撞器的空物体作为存档点，检测 **Player** 是否经过，然后将此存档点位置信息传递给 **GameManager** ，**GameManager** 记录到达的最前方的存档点位置，读档时将 **Player** 移至最后保存的存档点位置即可。





